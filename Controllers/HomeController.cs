using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealth.Data;
using SmartHealth.Helper;
using SmartHealth.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace SmartHealth.Controllers
{
    public class HomeController : Controller
    {
        private readonly HealthContext _context;

        public HomeController(HealthContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["Disease"] = _context.Diseases.ToList().Count;
            ViewData["Specialty"] = _context.Specialties.ToList().Count;
            ViewData["Patient"] = _context.Patients.ToList().Count;
            ViewData["Doctor"] = _context.Doctors.ToList().Count;

            return View();
        }

  
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Name,Password,RemeberMe")] Login login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string encryptedpassword = Encrypt.EncryptString(login.Password);

                var admin = _context.Admins
                    .Where(u => u.Name == login.Name && u.Password == encryptedpassword)
                    .FirstOrDefault();

                if (admin == null)
                {
                    ViewData["Error"] = "Name or Password incorrect";
                    return View(login);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, admin.ID.ToString()),
                    new Claim(ClaimTypes.Name, admin.Name),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                if (login.RemeberMe)
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddYears(1)
                    });
                }
                else
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                }

                return RedirectToLocal(returnUrl);
            }

            return View(login);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
