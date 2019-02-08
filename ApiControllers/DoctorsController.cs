using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Helper;
using SmartHealth.Models;
using SmartHealth.ViewModels;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class DoctorsController : ControllerBase
    {
        private readonly HealthContext _context;

        public DoctorsController(HealthContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors
                .Include(d => d.SpecialtyDoctors)
                .ThenInclude(s => s.Specialty)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor(DoctorData doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var hasedPassword = Encrypt.EncryptString(doctor.Doctor.Password);
            var user = await _context.Doctors
                .Where(u => u.Password == hasedPassword || u.Email == doctor.Doctor.Email)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                return BadRequest();
            }
            doctor.Doctor.Password = hasedPassword;
            await _context.Doctors.AddAsync(doctor.Doctor);
            foreach (var id in doctor.Specialty)
            {
                var specialtyDoctor = new SpecialtyDoctor
                {
                    DoctorID = doctor.Doctor.ID,
                    SpecialtyID = id
                };
                await _context.SpecialtyDoctors.AddAsync(specialtyDoctor);
            }
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorData item)
        {
            if (!ModelState.IsValid || id != item.Doctor.ID)
            {
                return BadRequest();
            }
            var doctor = await _context.Doctors.FindAsync(id);
            var hasedPassword = Encrypt.EncryptString(item.Doctor.Password);
            var user = await _context.Doctors
                .Where(u => u.Password == hasedPassword || u.Email == item.Doctor.Email)
                .FirstOrDefaultAsync();
            if (doctor == null || (user != null && user.ID != doctor.ID))
            {
                return BadRequest();
            }
            doctor.Name = item.Doctor.Name;
            doctor.Email = item.Doctor.Email;
            doctor.Password = hasedPassword;
            var specialtyDoctors = await _context.SpecialtyDoctors
                .Where(d => d.DoctorID == doctor.ID)
                .Include(s => s.Specialty)
                .ToListAsync();
            _context.SpecialtyDoctors.RemoveRange(specialtyDoctors);
            foreach (var ids in item.Specialty)
            {
                var specialtyDoctor = new SpecialtyDoctor
                {
                    DoctorID = doctor.ID,
                    SpecialtyID = ids
                };
                await _context.SpecialtyDoctors.AddAsync(specialtyDoctor);
            }
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            var specialtyDoctors = await _context.SpecialtyDoctors
                .Where(d => d.DoctorID == doctor.ID)
                .ToListAsync();
            _context.SpecialtyDoctors.RemoveRange(specialtyDoctors);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }
    }
}