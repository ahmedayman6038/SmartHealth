using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<string>> GetSymptom(string Name)
        {
            return _context.Symptoms
                    .Where(s => s.Name.Contains(Name))
                    .Select(s => s.Name)
                    .ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostSymptom(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }

            var check = _context.Symptoms
                .Where(d => d.Name == Name)
                .FirstOrDefault();

            if (check != null)
            {
                return BadRequest();
            }

            var symptom = new Symptom
            {
                Name = Name,
            };

            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();

            return Ok(symptom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSymptom([FromRoute] int id, string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }

            var symptom = await _context.Symptoms.FindAsync(id);

            var check = _context.Symptoms
                .Where(d => d.Name == Name)
                .FirstOrDefault();

            if (symptom == null || check.ID != symptom.ID)
            {
                return BadRequest();
            }

            symptom.Name = Name;

            _context.Symptoms.Update(symptom);
            await _context.SaveChangesAsync();

            return Ok(symptom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var symptom = await _context.Symptoms.FindAsync(id);

            if (symptom == null)
            {
                return NotFound();
            }

            var symptomDiseases = _context.SymptomDiseases
                .Where(d => d.SymptomID == symptom.ID)
                .ToList();

            foreach (var disease in symptomDiseases)
            {
                _context.SymptomDiseases.Remove(disease);
            }

            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();

            return Ok(symptom);
        }
    }
}