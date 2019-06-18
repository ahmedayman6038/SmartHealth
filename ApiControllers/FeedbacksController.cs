using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartHealth.Data;
using SmartHealth.Models;
using SmartHealth.ViewModels;

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly HealthContext _context;

        public FeedbacksController(HealthContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostFeedback(Mail mail)
        {
            if (ModelState.IsValid)
            {
                _ = SendMailAsync(mail);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendFeedback(Mail mail)
        {
            if (ModelState.IsValid)
            {
                var patient = await _context.Patients
                                .Where(p => p.Email == mail.Reciever)
                                .FirstOrDefaultAsync();
                if(patient == null)
                {
                    return NotFound("This Email Not founded");
                }
                Feedback feedback = new Feedback()
                {
                    Title = mail.Subject,
                    Content = mail.Content,
                    Patient = patient
                };
                await _context.Feedbacks.AddAsync(feedback);
                await _context.SaveChangesAsync();
                _ = SendMailAsync(mail);
                return Ok(mail);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return Ok(feedback);
        }

        private Task SendMailAsync(Mail mail)
        {
            return Task.Run(() =>
            {
                using (var smtp = HttpContext.RequestServices.GetRequiredService<SmtpClient>())
                {
                    var message = new MailMessage();
                    message.From = new MailAddress(smtp.Credentials
                        .GetCredential(smtp.Host, smtp.Port, smtp.PickupDirectoryLocation)
                        .UserName);
                    message.To.Insert(0, new MailAddress(mail.Reciever));
                    message.Subject = mail.Subject;
                    message.Body = mail.Content;
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            });
        }
    }
}