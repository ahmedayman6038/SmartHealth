using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var doctorRating = _context.DoctorRatings
                .Where(d => d.DoctorID == doctorId)
                .Select(d => d.Value)
                .ToList();
            var rating = doctorRating.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int rateSum = 0;
            int weightSum = 0;
            foreach (var rate in rating)
            {
                rateSum += (rate.Key * rate.Value);
                weightSum += rate.Value;
            }
            double totalRate = (double) rateSum / weightSum;
            return Math.Round(totalRate, 1);
        }

    }
}
