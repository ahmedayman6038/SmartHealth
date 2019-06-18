using System.Collections.Generic;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound("patient Not founded");
            }
            return Ok(patient);
        }

        [HttpGet("[action]")]
        public IActionResult DecryptPassword([FromQuery]string password)
        {
            var patientPassword = Encrypt.DecryptString(password);
            return Ok(patientPassword);
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

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<Assessment>> GetPredictionResults([FromRoute]int id)
        {
            var assessments = await _context.Assessments
                                .Where(a => a.Patient.ID == id)
                                .OrderByDescending(d => d.Date)
                                .ToListAsync();
            return assessments;
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

        [HttpPut("[action]")]
        public async Task<IActionResult> ResetPassword(Patient item)
        {
            var patient = await _context.Patients
                          .Where(u => u.Email == item.Email)
                          .FirstOrDefaultAsync();
            if(patient == null)
            {
                return NotFound("This Email Not Founded");
            }
            var hasedPassword = Encrypt.EncryptString(item.Password);
            var user = await _context.Patients
                       .Where(u => u.Password == hasedPassword)
                       .FirstOrDefaultAsync();
            if (user != null && user.ID != patient.ID)
            {
                return BadRequest("Password Already Taken");
            }
            patient.Password = hasedPassword;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateProfile(int id, Patient item)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var user = await _context.Patients
                     .Where(u => u.Email == item.Email)
                     .FirstOrDefaultAsync();
            if(user != null && user.ID != patient.ID)
            {
                return BadRequest("Patient Email existing");
            }
            patient.Name = item.Name;
            patient.Email = item.Email;
            patient.BirthDate = item.BirthDate;
            patient.Height = item.Height;
            patient.Weight = item.Weight;
            patient.Gender = item.Gender;
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
            var patientAssessments = await _context.Assessments
                                .Where(d => d.Patient.ID == patient.ID)
                                .ToListAsync();
            var patientRating = await _context.DoctorRatings
                                .Where(d => d.Patient.ID == patient.ID)
                                .ToListAsync();
            var patientFeedback = await _context.Feedbacks
                                    .Where(d => d.Patient.ID == patient.ID)
                                    .ToListAsync();
            _context.Feedbacks.RemoveRange(patientFeedback);
            _context.Assessments.RemoveRange(patientAssessments);
            _context.DoctorRatings.RemoveRange(patientRating);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

    }
}