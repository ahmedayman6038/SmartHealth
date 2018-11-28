using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Helper;
using SmartHealth.Models;

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

        [HttpPost]
        public async Task<IActionResult> PostPatient(int[] Specialty, string Name, string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                return BadRequest();
            }

            var hasedPassword = Encrypt.EncryptString(Password);

            var user = _context.Doctors
                .Where(u => u.Password == hasedPassword)
                .FirstOrDefault();

            if (user != null)
            {
                return BadRequest();
            }

            var doctor = new Doctor
            {
                Name = Name,
                Email = Email,
                Password = hasedPassword
            };

            _context.Doctors.Add(doctor);

            foreach (var id in Specialty)
            {
                var specialty = _context.Specialties.Find(id);
                var specialtyDoctor = new SpecialtyDoctor
                {
                    DoctorID = doctor.ID,
                    SpecialtyID = id
                };
                _context.SpecialtyDoctors.Add(specialtyDoctor);
            }

            await _context.SaveChangesAsync();

            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient([FromRoute] int id, int[] Specialty, string Name, string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                return BadRequest();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            var hasedPassword = Encrypt.EncryptString(Password);

            var user = _context.Doctors
                .Where(u => u.Password == hasedPassword)
                .FirstOrDefault();

            if (doctor == null || user.ID != doctor.ID)
            {
                return BadRequest();
            }

            doctor.Name = Name;
            doctor.Email = Email;
            doctor.Password = hasedPassword;

            var specialtyDoctors = _context.SpecialtyDoctors
                .Where(d => d.DoctorID == doctor.ID)
                .Include(s => s.Specialty)
                .ToList();

            _context.SpecialtyDoctors.RemoveRange(specialtyDoctors);

            foreach (var ids in Specialty)
            {
                var specialty = _context.Specialties.Find(ids);
                var specialtyDoctor = new SpecialtyDoctor
                {
                    DoctorID = doctor.ID,
                    SpecialtyID = ids
                };
                _context.SpecialtyDoctors.Add(specialtyDoctor);
            }

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();

            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return Ok(doctor);
        }
    }
}