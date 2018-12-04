using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth.Data;
using SmartHealth.Models;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController][Authorize]
    public class SpecialtiesController : ControllerBase
    {
        private readonly HealthContext _context;

        public SpecialtiesController(HealthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpecialty(string Name)
        {
            return _context.Specialties
                    .Where(s => s.Name.Contains(Name))
                    .Select(s => s.Name).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostSpecialty(string Name, string Details)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }

            var check = _context.Specialties
                .Where(d => d.Name == Name)
                .FirstOrDefault();

            if (check != null)
            {
                return BadRequest();
            }

            var specialty = new Specialty
            {
                Name = Name,
                Details = Details
            };

            _context.Specialties.Add(specialty);
            await _context.SaveChangesAsync();

            return Ok(specialty);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialty([FromRoute] int id, string Name, string Details)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }

            var specialty = await _context.Specialties.FindAsync(id);

            var check = _context.Specialties
                .Where(d => d.Name == Name)
                .FirstOrDefault();

            if (specialty == null || check.ID != specialty.ID)
            {
                return BadRequest();
            }

            specialty.Name = Name;
            specialty.Details = Details;

            _context.Specialties.Update(specialty);
            await _context.SaveChangesAsync();

            return Ok(specialty);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty([FromRoute] int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            var specialtyDoctors = _context.SpecialtyDoctors
                .Where(s => s.SpecialtyID == specialty.ID)
                .ToList();

            _context.SpecialtyDoctors.RemoveRange(specialtyDoctors);
            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();

            return Ok(specialty);
        }
    }
}