using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> PostAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var hasedPassword = Encrypt.EncryptString(admin.Password);
            var user = await _context.Admins
                .Where(u => u.Password == hasedPassword || u.Email == admin.Email)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                return BadRequest();
            }
            admin.Password = hasedPassword;
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return Ok(admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin item)
        {
            if (!ModelState.IsValid || id != item.ID)
            {
                return BadRequest();
            }
            var admin = await _context.Admins.FindAsync(id);
            var hasedPassword = Encrypt.EncryptString(item.Password);
            var user = await _context.Admins
                .Where(u => u.Password == hasedPassword || u.Email == item.Email)
                .FirstOrDefaultAsync();
            if (user != null && user.ID != item.ID)
            {
                return BadRequest();
            }
            admin.Name = item.Name;
            admin.Email = item.Email;
            admin.Password = hasedPassword;
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
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