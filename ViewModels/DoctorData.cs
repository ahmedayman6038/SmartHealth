using SmartHealth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHealth.ViewModels
{
    public class DoctorData
    {
        public Doctor Doctor { get; set; }
        public double Rating { get; set; }
        public int[] Specialty { get; set; }
    }
}
