using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly HealthContext _context;

        public SymptomsController(HealthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetSymptom(string Name)
        {
            return await _context.Symptoms
                    .Where(s => s.Name.Contains(Name))
                    .Select(s => s.Name)
                    .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostSymptom(Symptom symptom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var check = _context.Symptoms
                        .Where(d => d.Name == symptom.Name)
                        .FirstOrDefault();
            if (check != null)
            {
                return BadRequest();
            }
            await _context.Symptoms.AddAsync(symptom);
            await _context.SaveChangesAsync();
            return Ok(symptom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymptom(int id, Symptom item)
        {
            if (!ModelState.IsValid || id != item.ID)
            {
                return BadRequest();
            }
            var symptom = await _context.Symptoms.FindAsync(id);
            var check   = await _context.Symptoms
                            .Where(d => d.Name == item.Name)
                            .FirstOrDefaultAsync();
            if (symptom == null || (check != null && check.ID != item.ID))
            {
                return BadRequest();
            }
            symptom.Name = item.Name;
            _context.Symptoms.Update(symptom);
            await _context.SaveChangesAsync();
            return Ok(symptom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptom(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            var symptomDiseases = await _context.SymptomDiseases
                                    .Where(d => d.SymptomID == symptom.ID)
                                    .ToListAsync();
            _context.SymptomDiseases.RemoveRange(symptomDiseases);
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
            return Ok(symptom);
        }
    }
}