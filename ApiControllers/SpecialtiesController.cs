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
    public class SpecialtiesController : ControllerBase
    {
        private readonly HealthContext _context;

        public SpecialtiesController(HealthContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Specialty>> GetAllSpecialty()
        {
            return await _context.Specialties
                    .ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetSpecialty(string Name)
        {
            return await _context.Specialties
                    .Where(s => s.Name.Contains(Name))
                    .Select(s => s.Name)
                    .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostSpecialty(Specialty specialty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var check = await _context.Specialties
                        .Where(d => d.Name == specialty.Name)
                        .FirstOrDefaultAsync();
            if (check != null)
            {
                return BadRequest();
            }
            await _context.Specialties.AddAsync(specialty);
            await _context.SaveChangesAsync();
            return Ok(specialty);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialty(int id, Specialty item)
        {
            if (!ModelState.IsValid || id != item.ID)
            {
                return BadRequest();
            }
            var specialty = await _context.Specialties.FindAsync(id);
            var check = await _context.Specialties
                        .Where(d => d.Name == specialty.Name)
                        .FirstOrDefaultAsync();
            if (specialty == null || (check != null && check.ID != specialty.ID))
            {
                return BadRequest();
            }
            specialty.Name = item.Name;
            specialty.Details = item.Details;
            _context.Specialties.Update(specialty);
            await _context.SaveChangesAsync();
            return Ok(specialty);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            var specialtyDoctors = await _context.SpecialtyDoctors
                                   .Where(s => s.SpecialtyID == specialty.ID)
                                   .ToListAsync();
            _context.SpecialtyDoctors.RemoveRange(specialtyDoctors);
            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();
            return Ok(specialty);
        }
    }
}