using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth.Data;
using SmartHealth.Helper;
using SmartHealth.Models;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController][Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly HealthContext _context;

        public PatientsController(HealthContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(string Name, string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                return BadRequest();
            }

            var hasedPassword = Encrypt.EncryptString(Password);

            var user = _context.Patients
                .Where(u => u.Password == hasedPassword)
                .FirstOrDefault();

            if (user != null)
            {
                return BadRequest();
            }

            var patient = new Patient
            {
                Name = Name,
                Email = Email,
                Password = hasedPassword
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient([FromRoute] int id, string Name, string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                return BadRequest();
            }

            var patient = await _context.Patients.FindAsync(id);
            var hasedPassword = Encrypt.EncryptString(Password);

            var user = _context.Patients
                .Where(u => u.Password == hasedPassword)
                .FirstOrDefault();

            if (patient == null || (user != null && user.ID != patient.ID))
            {
                return BadRequest();
            }

            patient.Name = Name;
            patient.Email = Email;
            patient.Password = hasedPassword;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return Ok(patient);
        }
    }
}