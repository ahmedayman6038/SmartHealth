using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;
using SmartHealth.ViewModels;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly HealthContext _context;

        public DiseasesController(HealthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetDiseaseAsync(string Name)
        {
            return await _context.Diseases
                .Where(s => s.Name.Contains(Name))
                .Select(s => s.Name)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostDisease(DiseaseData disease)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var check = await _context.Diseases
                .Where(d => d.Name == disease.Disease.Name)
                .FirstOrDefaultAsync();
            var type = await _context.Specialties.FindAsync(disease.Type);
            if(check != null || type == null)
            {
                return BadRequest();
            }
            disease.Disease.Specialty = type;
            await _context.Diseases.AddAsync(disease.Disease);
            foreach (var id in disease.symptoms)
            {
                var symptomDiseases = new SymptomDisease
                {
                    DiseaseID = disease.Disease.ID,
                    SymptomID = id
                };
                await _context.SymptomDiseases.AddAsync(symptomDiseases);
            }
            await _context.SaveChangesAsync();
            return Ok(disease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisease(int id, DiseaseData item)
        {
            if (!ModelState.IsValid || id != item.Disease.ID)
            {
                return BadRequest();
            }
            var disease = await _context.Diseases.FindAsync(id);
            var type = await _context.Specialties.FindAsync(item.Type);
            var check = await _context.Diseases
                .Where(d => d.Name == item.Disease.Name)
                .FirstOrDefaultAsync();
            if (disease == null || type == null || (check != null && check.ID != item.Disease.ID))
            {
                return BadRequest();
            }
            disease.Name = item.Disease.Name;
            disease.Details = item.Disease.Details;
            disease.Specialty = type;
            var symptomDiseases = await _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .Include(s => s.Symptom)
                .ToListAsync();
            _context.SymptomDiseases.RemoveRange(symptomDiseases);
            foreach (var ids in item.symptoms)
            {
                var symptomDisease = new SymptomDisease
                {
                    DiseaseID = disease.ID,
                    SymptomID = ids
                };
                await _context.SymptomDiseases.AddAsync(symptomDisease);
            }
            _context.Diseases.Update(disease);
            await _context.SaveChangesAsync();
            return Ok(disease);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }
            var symptomDiseases = await _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .ToListAsync();
            _context.SymptomDiseases.RemoveRange(symptomDiseases);
            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();
            return Ok(disease);
        }
    }
}