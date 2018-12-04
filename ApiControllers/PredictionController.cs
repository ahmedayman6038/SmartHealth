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

namespace SmartHealth.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly HealthContext _context;

        public PredictionController(HealthContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSymptom(string Name)
        {
            return _context.Symptoms
                    .Where(s => s.Name.Contains(Name))
                    .Select(s => s.Name).ToList();
        }

        [HttpGet("Initialize")]
        public ActionResult<IEnumerable<Symptom>> InitializePredict(string SName)
        {
            if (string.IsNullOrWhiteSpace(SName))
            {
                return BadRequest();
            }

            var symptom = _context.Symptoms
                .Where(s => s.Name == SName)
                .FirstOrDefault();

            if (symptom == null)
            {
                return NotFound();
            }

            var diseasesID = _context.SymptomDiseases
               .Where(d => d.SymptomID == symptom.ID)
               .Select(d => d.DiseaseID).ToList();

            var chosenSymptoms = new List<int>();
            var currentSymptoms = new List<Symptom>();

            chosenSymptoms.Add(symptom.ID);
            HttpContext.Session.SetObjectAsJson("ChosenSymptoms", chosenSymptoms);

            foreach (var id in diseasesID)
            {
                int? symptomID = _context.SymptomDiseases
                    .Where(d => d.DiseaseID == id && !currentSymptoms.Any(s => s.ID == d.SymptomID))
                    .Select(s => s.SymptomID).ToList()
                    .Except(chosenSymptoms)
                    .FirstOrDefault();

                if (symptomID == null)
                    continue;

                var newSymptom = _context.Symptoms.Find(symptomID);
                currentSymptoms.Add(newSymptom);
            }

            return currentSymptoms;
        }
    }
}