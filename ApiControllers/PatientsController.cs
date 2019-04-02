using System.Linq;
using System.Threading.Tasks;
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
    public class PatientsController : ControllerBase
    {
        private readonly HealthContext _context;

        public PatientsController(HealthContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string encryptedpassword = Encrypt.EncryptString(login.Password);
            var patient = await _context.Patients
                .Where(u => u.Email == login.Email && u.Password == encryptedpassword)
                .FirstOrDefaultAsync();
            if (patient == null)
            {
                return NotFound("This Patient Not Exist");
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var hasedPassword = Encrypt.EncryptString(patient.Password);
            var user = await _context.Patients
                       .Where(u => u.Password == hasedPassword || u.Email == patient.Email)
                       .FirstOrDefaultAsync();
            if (user != null)
            {
                return BadRequest();
            }
            patient.Password = hasedPassword;
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient item)
        {
            if (!ModelState.IsValid || id != item.ID)
            {
                return BadRequest();
            }
            var patient = await _context.Patients.FindAsync(id);
            var hasedPassword = Encrypt.EncryptString(item.Password);
            var user = await _context.Patients
                       .Where(u => u.Password == hasedPassword || u.Email == item.Email)
                       .FirstOrDefaultAsync();
            if (patient == null || (user != null && user.ID != item.ID))
            {
                return BadRequest();
            }
            patient.Name = item.Name;
            patient.Email = item.Email;
            patient.Password = hasedPassword;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
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