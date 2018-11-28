using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;

namespace SmartHealth.Controllers
{
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

            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var specialtyDoctors = _context.SpecialtyDoctors
               .Where(d => d.DoctorID == doctor.ID)
               .Include(s => s.Specialty).ToList();

            if (specialtyDoctors.Count == 0)
            {
                specialtyDoctors.Add(new SpecialtyDoctor
                {
                    Specialty = new Specialty(),
                    Doctor = doctor
                });
            }

            return View(specialtyDoctors);
        }

        public IActionResult Create()
        {
            ViewData["Specialty"] = _context.Specialties
               .Select(n => new SelectListItem
               {
                   Value = n.ID.ToString(),
                   Text = n.Name
               }).ToList();
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

            ViewData["Specialty"] = _context.Specialties
              .Select(n => new SelectListItem
              {
                  Value = n.ID.ToString(),
                  Text = n.Name
              }).ToList();

            ViewData["SpecialtyDoctor"] = _context.SpecialtyDoctors
                .Where(d => d.DoctorID == doctor.ID)
                .Select(s => s.SpecialtyID).ToList();

            return View(doctor);
        }
    }
}
