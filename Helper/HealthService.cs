using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartHealth.Data;
using SmartHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHealth.Helper
{
    public static class HealthService
    {
        public static Task<List<Symptom>> GetNextSymptomsAsync(HealthContext context,HttpContext http, int symptomId)
        {
            return Task.Run(() =>
            {
                var diseasesID = context.SymptomDiseases
                    .Where(d => d.SymptomID == symptomId)
                    .Select(d => d.DiseaseID).ToList();

                var chosenSymptoms = http.Session.GetObjectFromJson<List<int>>("ChosenSymptoms");
                int[][] counter = new int[diseasesID.Count][];
                var current = 0;
                foreach (var id in diseasesID)
                {
                    var symptoms = context.SymptomDiseases
                        .Where(d => d.DiseaseID == id && !chosenSymptoms.Contains(d.SymptomID))
                        .Include(s => s.Symptom)
                        .Select(s => s.Symptom)
                        .ToList();
                    counter[current++] = new int[symptoms.Count];
                }

                return new List<Symptom>();
            });
        }
    }
}
