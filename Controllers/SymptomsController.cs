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
    public class SymptomsController : Controller
    {
        private readonly HealthContext _context;

        public SymptomsController(HealthContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Symptoms
                .Include(s => s.SymptomDiseases)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var symptom = await _context.Symptoms
                .Where(s => s.ID == id)
                .Include(s => s.SymptomDiseases)
                .ThenInclude(s => s.Disease)
                .FirstOrDefaultAsync();
            if (symptom == null)
            {
                return NotFound();
            }
            return View(symptom);
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
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            return View(symptom);
        }
    }
}
