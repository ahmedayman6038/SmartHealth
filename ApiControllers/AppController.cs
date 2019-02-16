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
        private static List<int> chosenSymptoms;
        private static List<int> selectedSymptoms;
        private readonly App myApp;

        public AppController(HealthContext context)
        {
            _context = context;
            myApp = new App(_context);
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

        [HttpGet("[action]")]
        public async Task<IActionResult> InitializePrediction(string name)
        {
            var symptom = await _context.Symptoms
                .Where(s => s.Name == name)
                .FirstOrDefaultAsync();
            if (symptom == null)
            {
                return NotFound();
            }
            chosenSymptoms = new List<int>();
            selectedSymptoms = new List<int>();
            chosenSymptoms.Add(symptom.ID);
            return Ok(symptom);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<Symptom>>> StartPrediction([FromRoute]int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }
            if (!selectedSymptoms.Contains(id))
            {
                selectedSymptoms.Add(id);
            }
            var symptoms = await GetNextSymptomsAsync(id);
            return symptoms;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PredictionResult>> EndPrediction()
        {
            var predictionResult = await GetPredictionResult();
            chosenSymptoms = null;
            selectedSymptoms = null;
            return Ok(predictionResult);
        }

        private Task<List<Symptom>> GetNextSymptomsAsync(int symptomId)
        {
            return Task.Run(() =>
            {
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
                return nextSymptoms;
            });
        }

        private Task<PredictionResult> GetPredictionResult()
        {
            return Task.Run(() =>
            {
                PredictionResult result = new PredictionResult();
                var diseasesList = new List<int>();
                foreach (var id in selectedSymptoms)
                {
                    var diseases = _context.SymptomDiseases
                        .Where(d => d.SymptomID == id)
                        .Select(s => s.DiseaseID)
                        .ToList();
                    diseasesList.AddRange(diseases);
                }
                var diseasesFrequency = diseasesList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                var maxFrequency = diseasesFrequency.OrderByDescending(s => s.Value).First().Value;
                var diseasesId = diseasesFrequency
                       .Where(f => f.Value == maxFrequency)
                       .Select(s => s.Key)
                       .ToList();
                var selectedDiseases = _context.Diseases
                      .Where(s => diseasesId.Contains(s.ID))
                      .Include(s => s.Specialty)
                      .ToList();
                result.Diseases = selectedDiseases;
                result.Doctors = new List<Doctor>();
                foreach (var disease in selectedDiseases)
                {
                    result.Doctors.AddRange(myApp.GetSuggestedDoctors(disease.Specialty.ID));
                }
                result.Doctors.Distinct();
                return result;
            });
        }
    }
}