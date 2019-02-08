using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class AppController : ControllerBase
    {
        private readonly HealthContext _context;

        public AppController(HealthContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Inputs");
            }
            string encryptedpassword = Encrypt.EncryptString(login.Password);
            var patient = await _context.Patients
                        .Where(u => u.Email == login.Email && u.Password == encryptedpassword)
                        .FirstOrDefaultAsync();
            if (patient == null)
            {
                return NotFound("This user not founded");
            }
            return Ok("Valid Login");
        }

        [HttpGet("Predicit/{id}")]
        public async Task<ActionResult<List<Symptom>>> InitializePredict([FromRoute] int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);

            if (symptom == null)
            {
                return NotFound();
            }

            var chosenSymptoms = new List<int>();
            //var currentSymptoms = new List<Symptom>();

            chosenSymptoms.Add(id);
            HttpContext.Session.SetObjectAsJson("ChosenSymptoms", chosenSymptoms);

            var symptoms = await HealthService.GetNextSymptomsAsync(_context,ControllerContext.HttpContext, id);
          

            //foreach (var id in diseasesID)
            //{
            //    int? symptomID = _context.SymptomDiseases
            //        .Where(d => d.DiseaseID == id && !currentSymptoms.Any(s => s.ID == d.SymptomID))
            //        .Select(s => s.SymptomID).ToList()
            //        .Except(chosenSymptoms)
            //        .FirstOrDefault();

            //    if (symptomID == null)
            //        continue;

            //    var newSymptom = _context.Symptoms.Find(symptomID);
            //    currentSymptoms.Add(newSymptom);
            //}

            return symptoms;
        }
    }
}