using System;
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
        private App myApp;

        public DoctorsController(HealthContext context)
        {
            _context = context;
            myApp = new App(_context);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<DoctorProfile>> GetDoctorProfile([FromRoute] int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if(doctor == null)
            {
                return NotFound();
            }
            DoctorProfile doctorProfile = new DoctorProfile
            {
                ID = doctor.ID,
                Name = doctor.Name,
                City = doctor.City,
                Address = doctor.Address,
                Information = doctor.Information,
                Rating = myApp.CalculateDoctorRating(doctor.ID)
            };
            return doctorProfile;
        }

        [HttpPost("[action]/{id}/{patientId}")]
        public async Task<ActionResult<DoctorRating>> Rate([FromRoute] int id, [FromRoute] int patientId, [FromQuery] int value)
        {
            DoctorRating doctorRating = await _context.DoctorRatings
                                .Where(r => r.DoctorID == id && r.PatientID == patientId)
                                .SingleOrDefaultAsync();
            if(doctorRating == null)
            {
                doctorRating = new DoctorRating();
                doctorRating.DoctorID = id;
                doctorRating.PatientID = patientId;
                doctorRating.Value = value;
                await _context.DoctorRatings.AddAsync(doctorRating);
            }
            else
            {
                doctorRating.Value = value;
                _context.DoctorRatings.Update(doctorRating);
            }
            await _context.SaveChangesAsync();
            return Ok(doctorRating);
        }
        [HttpGet("[action]/{id}/{patientId}")]
        public async Task<ActionResult<int>> GetRate([FromRoute] int id, [FromRoute] int patientId)
        {
            var doctorRating = await _context.DoctorRatings
                                .Where(r => r.DoctorID == id && r.PatientID == patientId)
                                .SingleOrDefaultAsync();
            if (doctorRating == null)
            {
                return NotFound("Not founded");
            }
            return Ok(doctorRating.Value);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<DoctorProfile>> GetDoctorsBySpecialties([FromRoute] int id)
        {
            List<Doctor> doctors = await _context.SpecialtyDoctors
                .Where(s => s.SpecialtyID == id)
                .Include(d => d.Doctor)
                .Select(d => d.Doctor)
                .ToListAsync();
            return await myApp.GetDoctorsData(doctors);
        }

        [HttpGet]
        public async Task<IEnumerable<DoctorProfile>> GetDoctor(string Name)
        {
            List<Doctor> doctors = await _context.Doctors
                    .Where(s => s.Name.Contains(Name))
                    .ToListAsync();
            return await myApp.GetDoctorsData(doctors);
        }

        [HttpPost("Rate")]
        public async Task<IActionResult> DoctorRating(DoctorRating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var patient = await _context.Patients.FindAsync(rating.PatientID);
            var doctor = await _context.Doctors.FindAsync(rating.DoctorID);
            if(patient == null || doctor == null)
            {
                return NotFound("Patient or Doctor not exist");
            }
            var doctorRate = await _context.DoctorRatings
                .Where(r => r.PatientID == rating.PatientID && r.DoctorID == rating.DoctorID)
                .FirstOrDefaultAsync();
            if(doctorRate == null)
            {
                await _context.DoctorRatings.AddAsync(rating);
            }
            else
            {
                doctorRate.Value = rating.Value;
                doctorRate.Comment = rating.Comment;
                _context.DoctorRatings.Update(doctorRate);
            }
            await _context.SaveChangesAsync();
            return Ok(rating);
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
            doctor.City = item.Doctor.City;
            doctor.Address = item.Doctor.Address;
            doctor.Information = item.Doctor.Information;
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
            var doctorsRating = await _context.DoctorRatings
                .Where(d => d.DoctorID == doctor.ID)
                .ToListAsync();
            _context.SpecialtyDoctors.RemoveRange(specialtyDoctors);
            _context.DoctorRatings.RemoveRange(doctorsRating);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }
    }
}