using SmartHealth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHealth.ViewModels
{
    public class DiseaseData
    {
        [Required]
        public Disease Disease { get; set; }
        public int[] symptoms { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
