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
    public class AppController : ControllerBase
    {
        private readonly HealthContext _context;
        private List<int> chosenSymptoms;
        private List<int> selectedSymptoms;
        private App myApp;
        public AppController(HealthContext context)
        {
            _context = context;
            myApp = new App(_context);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PatientLogin(Login login,[FromQuery] string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string encryptedpassword;
            if (type == "normal")
            {
                encryptedpassword = Encrypt.EncryptString(login.Password);
            }
            else
            {
                encryptedpassword = login.Password;
            }
            var patient = await _context.Patients
                .Where(u => u.Email == login.Email && u.Password == encryptedpassword)
                .FirstOrDefaultAsync();
            if (patient == null)
            {
                return NotFound("This Patient Not Exist");
            }
            return Ok(patient);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult InitializePrediction([FromRoute] int id)
        {
            chosenSymptoms = new List<int>();
            selectedSymptoms = new List<int>();
            chosenSymptoms.Add(id);
            HttpContext.Session.SetObjectAsJson("chosenSymptoms", chosenSymptoms);
            HttpContext.Session.SetObjectAsJson("selectedSymptoms", selectedSymptoms);
            return Ok(id);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<Symptom>>> Predict([FromRoute]int id)
        {
            selectedSymptoms = HttpContext.Session.GetObjectFromJson<List<int>>("selectedSymptoms");
            if (!selectedSymptoms.Contains(id))
            {
                selectedSymptoms.Add(id);
            }
            HttpContext.Session.SetObjectAsJson("selectedSymptoms", selectedSymptoms);
            var symptoms = await GetNextSymptomsAsync(id);
            return Ok(symptoms);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Assessment>> EndPrediction([FromRoute]int id)
        {
            selectedSymptoms = HttpContext.Session.GetObjectFromJson<List<int>>("selectedSymptoms");
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound("Patient not founded");
            }
            string info = "";
            foreach (var item in selectedSymptoms)
            {
                info += item.ToString() + "/";
            }
            var firstSyptom = await _context.Symptoms.FindAsync(selectedSymptoms.ElementAt(0));
            if (firstSyptom == null)
            {
                return NotFound("First symptom not founder");
            }
            Assessment assessment = new Assessment();
            assessment.Name = firstSyptom.Name;
            assessment.Information = Encrypt.EncryptString(info);
            assessment.Patient = patient;
            await _context.Assessments.AddAsync(assessment);
            await _context.SaveChangesAsync();
            return Ok(assessment);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PredictionResult>> GetPredictionResult([FromRoute]int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            if(assessment == null)
            {
                return NotFound("Result not founded");
            }
            string[] info = Encrypt.DecryptString(assessment.Information).Split("/");
            selectedSymptoms = new List<int>();
            for (int i = 0; i < info.Length - 1; i++)
            {
                int symptomId = int.Parse(info[i]);
                selectedSymptoms.Add(symptomId);
            }
            var predictionResult = await myApp.GetPredictionResult(selectedSymptoms);
            return Ok(predictionResult);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletePredictionResult([FromRoute]int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }
            _context.Assessments.Remove(assessment);
            await _context.SaveChangesAsync();
            return Ok(assessment);
        }

        private Task<List<Symptom>> GetNextSymptomsAsync(int symptomId)
        {
            return Task.Run(() =>
            {
                chosenSymptoms = HttpContext.Session.GetObjectFromJson<List<int>>("chosenSymptoms");
                var nextSymptoms = new List<Symptom>();
                // Get all diseases of this symptom
                var diseasesID = _context.SymptomDiseases
                    .Where(d => d.SymptomID == symptomId)
                    .Select(d => d.DiseaseID)
                    .ToList();
                // Get all symptoms of each disease
                var symptomsList = new List<int>();
                foreach (var id in diseasesID)
                {
                    var symptoms = _context.SymptomDiseases
                        .Where(d => d.DiseaseID == id && !chosenSymptoms.Contains(d.SymptomID))
                        .Select(s => s.SymptomID)
                        .ToList();
                    symptomsList.AddRange(symptoms);
                }
                if (symptomsList.Count == 0)
                {
                    return nextSymptoms;
                }
                // Get frequency of each symptom
                var symptomsFrequency = symptomsList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                // Get minumum frequency symptoms
                var minFrequency = symptomsFrequency.OrderBy(s => s.Value).First().Value;
                var symptomsId = symptomsFrequency
                    .Where(f => f.Value == minFrequency)
                    .Select(s => s.Key)
                    .ToList();
                // Select symptom for each disease
                foreach (var did in diseasesID)
                {
                    Symptom selectedSymptom = null;
                    var diseaseSymptoms = _context.SymptomDiseases
                        .Where(s => s.DiseaseID == did)
                        .Include(s => s.Symptom)
                        .Select(s => s.Symptom)
                        .ToList();
                    // Try select symptom from min frequency symptoms
                    foreach (var sid in symptomsId)
                    {
                        var symptom = diseaseSymptoms
                            .Where(s => s.ID == sid)
                            .FirstOrDefault();
                        if (symptom != null)
                        {
                            symptomsId.Remove(symptom.ID);
                            selectedSymptom = symptom;
                            break;
                        }
                    }
                    if (selectedSymptom == null)
                    {
                        // Try select secound min frequency symptom from this disease  
                        int minValue = int.MaxValue;
                        foreach (var item in symptomsFrequency)
                        {
                            var symptom = diseaseSymptoms
                                .Where(s => s.ID == item.Key)
                                .FirstOrDefault();
                            if (symptom != null)
                            {
                                var itemValue = item.Value;
                                if (itemValue < minValue)
                                {
                                    minValue = itemValue;
                                    selectedSymptom = symptom;
                                }
                            }
                            if (minValue == minFrequency + 1)
                            {
                                break;
                            }
                        }
                    }
                    if (selectedSymptom != null)
                    {
                        nextSymptoms.Add(selectedSymptom);
                        chosenSymptoms.Add(selectedSymptom.ID);
                        symptomsFrequency.Remove(selectedSymptom.ID);
                    }
                }
                HttpContext.Session.SetObjectAsJson("chosenSymptoms", chosenSymptoms);
                return nextSymptoms;
            });
        }

      
    }
}