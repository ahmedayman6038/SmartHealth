using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHealth.Data;
using Microsoft.EntityFrameworkCore;
using SmartHealth.ViewModels;

namespace SmartHealth.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly HealthContext _context;

        public FeedbacksController(HealthContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Feedbacks
                .Include(p => p.Patient)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var mail = new Mail();
            mail.Reciever = patient.Email;           
            return View(mail);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var feedback = await _context.Feedbacks
                .Include(p => p.Patient)
                .Where(f => f.ID == id)
                .FirstOrDefaultAsync();
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

    }
}