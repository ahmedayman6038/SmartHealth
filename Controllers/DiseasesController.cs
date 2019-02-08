using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;

namespace SmartHealth.Controllers
{
    [Authorize]
    public class DiseasesController : Controller
    {
        private readonly HealthContext _context;

        public DiseasesController(HealthContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Diseases
                .Include(s => s.SymptomDiseases)
                .Include(s => s.Specialty)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var disease = await _context.Diseases
                .Where(d => d.ID == id)
                .Include(d => d.Specialty)
                .Include(d => d.SymptomDiseases)
                .ThenInclude(d => d.Symptom)
                .FirstOrDefaultAsync();
            if (disease == null)
            {
                return NotFound();
            }
            return View(disease);
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
            var disease = await _context.Diseases
                .Where(d => d.ID == id)
                .Include(s => s.Specialty)
                .FirstOrDefaultAsync();
            if (disease == null)
            {
                return NotFound();
            }
            await FillSelectListAsync();
            ViewData["DiseaseSymptoms"] = await _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .Select(s => s.SymptomID)
                .ToListAsync();
            return View(disease);
        }

        private async Task FillSelectListAsync()
        {
            ViewData["Symptoms"] = await _context.Symptoms
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToListAsync();
            ViewData["Type"] = await _context.Specialties
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToListAsync();
        }
    }
}
