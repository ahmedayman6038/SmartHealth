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
    public class DiseasesController : Controller
    {
        private readonly HealthContext _context;

        public DiseasesController(HealthContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Diseases.Include(s => s.SymptomDiseases).Include(s => s.Specialty).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = await _context.Diseases.FindAsync(id);

            if (disease == null)
            {
                return NotFound();
            }

            var symptomDisease = _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .Include(s => s.Symptom)
                .Include(s => s.Disease.Specialty)
                .ToList();

            if (symptomDisease.Count == 0)
            {
                symptomDisease.Add(new SymptomDisease
                {
                    Disease = disease,
                    Symptom = new Symptom()
                });
            }

            return View(symptomDisease);
        }

        public IActionResult Create()
        {
            ViewData["Symptoms"] = _context.Symptoms
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToList();

            ViewData["Type"] = _context.Specialties
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToList();

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disease = _context.Diseases
                .Where(d => d.ID == id)
                .Include(s => s.Specialty)
                .FirstOrDefault();

            if (disease == null)
            {
                return NotFound();
            }

            ViewData["Symptoms"] = _context.Symptoms
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToList();

            ViewData["Type"] = _context.Specialties
                .Select(n => new SelectListItem
                {
                    Value = n.ID.ToString(),
                    Text = n.Name
                }).ToList();

            ViewData["DiseaseSymptoms"] = _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .Select(s => s.SymptomID).ToList();

            return View(disease);
        }
    }
}
