using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;

namespace SmartHealth.Controllers
{
    [Authorize]
    public class SpecialtiesController : Controller
    {
        private readonly HealthContext _context;

        public SpecialtiesController(HealthContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Specialties.Include(s => s.SpecialtyDoctors).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialties.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            var specialtyDoctors = _context.SpecialtyDoctors
                .Where(s => s.SpecialtyID == specialty.ID)
                .Include(d => d.Doctor).ToList();

            if (specialtyDoctors.Count == 0)
            {
                specialtyDoctors.Add(new SpecialtyDoctor
                {
                    Specialty = specialty,
                    Doctor = new Doctor()
                });
            }

            return View(specialtyDoctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialties.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }
    }
}
