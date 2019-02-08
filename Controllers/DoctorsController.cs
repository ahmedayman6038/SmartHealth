using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;

namespace SmartHealth.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly HealthContext _context;

        public DoctorsController(HealthContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctor = await _context.Doctors
                .Where(d => d.ID == id)
                .Include(s => s.SpecialtyDoctors)
                .ThenInclude(s => s.Specialty)
                .FirstOrDefaultAsync();
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public async Task<IActionResult> Create()
        {
            await FillSelectListAsync();
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            await FillSelectListAsync();
            ViewData["SpecialtyDoctor"] = await _context.SpecialtyDoctors
                .Where(d => d.DoctorID == doctor.ID)
                .Select(s => s.SpecialtyID)
                .ToListAsync();
            return View(doctor);
        }

        private async Task FillSelectListAsync()
        {
            ViewData["Specialty"] = await _context.Specialties
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToListAsync();
        }
    }
}
