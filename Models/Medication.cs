using System;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Medication
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Patient Patient { get; set; }
    }
}
