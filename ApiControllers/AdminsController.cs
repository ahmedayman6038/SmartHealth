using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHealth.Data;
using SmartHealth.Helper;
using SmartHealth.Models;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly HealthContext _context;

        public AdminsController(HealthContext context)
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

            var user = _context.Admins
                .Where(u => u.Password == hasedPassword)
                .FirstOrDefault();

            if (user != null)
            {
                return BadRequest();
            }

            var admin = new Admin
            {
                Name = Name,
                Email = Email,
                Password = hasedPassword
            };

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient([FromRoute] int id, string Name, string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                return BadRequest();
            }

            var admin = await _context.Admins.FindAsync(id);
            var hasedPassword = Encrypt.EncryptString(Password);

            var user = _context.Admins
                .Where(u => u.Password == hasedPassword)
                .FirstOrDefault();

            if (admin == null || user.ID != admin.ID)
            {
                return BadRequest();
            }

            admin.Name = Name;
            admin.Email = Email;
            admin.Password = hasedPassword;

            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);
        }
    }
}