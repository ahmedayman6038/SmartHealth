using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;
using SmartHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHealth.Helper
{
    public class App
    {
        private readonly HealthContext _context;

        public App(HealthContext context)
        {
            _context = context;
        }

        public List<Doctor> GetSuggestedDoctors(int speciltyId)
        {
            var doctors = _context.SpecialtyDoctors
               .Where(s => s.SpecialtyID == speciltyId)
               .Include(s => s.Doctor)
               .Select(s => s.Doctor)
               .ToList();
            if (doctors.Count == 0)
            {
                return doctors;
            }
            var doctorRating = doctors.GroupBy(x => x.ID).ToDictionary(x => x.Key, x => CalculateDoctorRating(x.Key));
            var maxRate = doctorRating.OrderByDescending(x => x.Value).First().Value;
            var doctorsId = doctorRating
                    .Where(d => d.Value == maxRate)
                    .Select(s => s.Key)
                    .ToList();
            return doctors.Where(s => doctorsId.Contains(s.ID)).ToList();
        }

        public double CalculateDoctorRating(int doctorId)
        {
            List<int> doctorRating = _context.DoctorRatings
                .Where(d => d.DoctorID == doctorId)
                .Select(d => d.Value)
                .ToList();
            if(doctorRating.Count > 0)
            {
                var rating = doctorRating.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
                int rateSum = 0;
                int weightSum = 0;
                foreach (var rate in rating)
                {
                    rateSum += (rate.Key * rate.Value);
                    weightSum += rate.Value;
                }
                double totalRate = (double)rateSum / weightSum;
                return Math.Round(totalRate, 1);
            }
            return 0;
        }

        public Task<List<DoctorProfile>> GetDoctorsData(List<Doctor> doctors)
        {
            return Task.Run(() =>
            {
                return doctors.Select(d => new DoctorProfile
                {
                    ID = d.ID,
                    Name = d.Name,
                    City = d.City,
                    Rating = CalculateDoctorRating(d.ID)
                }).ToList();
            });
        }

        public Task<PredictionResult> GetPredictionResult(List<int> selectedSymptoms)
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
                    result.Doctors.AddRange(GetSuggestedDoctors(disease.Specialty.ID));
                }
                var doctorsList = result.Doctors.GroupBy(x => x.ID)
                                        .Select(g => g.First())
                                        .ToList();
                result.Doctors = doctorsList;
                return result;
            });
        }
    }
}
