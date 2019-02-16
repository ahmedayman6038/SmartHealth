using SmartHealth.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.ViewModels
{
    public class DiseaseData
    {
        [Required]
        public Disease Disease { get; set; }
        public int[] Symptoms { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
