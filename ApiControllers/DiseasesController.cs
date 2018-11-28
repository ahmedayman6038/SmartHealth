using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;

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

        [HttpPost]
        public async Task<IActionResult> PostDisease(int[] Symptom, string Name, string Details, int? Type)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }

            var check = _context.Diseases
                .Where(d => d.Name == Name)
                .FirstOrDefault();

            var type = await _context.Specialties.FindAsync(Type);

            if(check != null || type == null)
            {
                return BadRequest();
            }

            var disease = new Disease
            {
                Name = Name,
                Details = Details,
                Specialty = type
            };

            _context.Diseases.Add(disease);

            foreach (var id in Symptom)
            {
                var symptom = _context.Symptoms.Find(id);
                var symptomDiseases = new SymptomDisease
                {
                    DiseaseID = disease.ID,
                    SymptomID = id
                };
                _context.SymptomDiseases.Add(symptomDiseases);
            }

            await _context.SaveChangesAsync();

            return Ok(disease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisease([FromRoute] int id, int[] Symptom, string Name, string Details, int? Type)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }

            var disease = await _context.Diseases.FindAsync(id);
            var type = await _context.Specialties.FindAsync(Type);

            var check = _context.Diseases
                .Where(d => d.Name == Name)
                .FirstOrDefault();

            if (disease == null || type == null || check.ID != disease.ID)
            {
                return BadRequest();
            }

            disease.Name = Name;
            disease.Details = Details;
            disease.Specialty = type;

            var symptomDiseases = _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .Include(s => s.Symptom)
                .ToList();

            _context.SymptomDiseases.RemoveRange(symptomDiseases);

            foreach (var ids in Symptom)
            {
                var symptom = _context.Symptoms.Find(ids);
                var symptomDisease = new SymptomDisease
                {
                    DiseaseID = disease.ID,
                    SymptomID = ids
                };
                _context.SymptomDiseases.Add(symptomDisease);
            }

            _context.Diseases.Update(disease);
            await _context.SaveChangesAsync();

            return Ok(disease);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disease = await _context.Diseases.FindAsync(id);

            if (disease == null)
            {
                return NotFound();
            }

            var symptomDiseases = _context.SymptomDiseases
                .Where(d => d.DiseaseID == disease.ID)
                .ToList();

            foreach(var symptom in symptomDiseases)
            {
                _context.SymptomDiseases.Remove(symptom);
            }

            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();

            return Ok(disease);
        }
    }
}