using SmartHealth.Models;
using System.Collections.Generic;

namespace SmartHealth.ViewModels
{
    public class PredictionResult
    {
        public List<Disease> Diseases { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
