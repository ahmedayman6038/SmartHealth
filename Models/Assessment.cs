using System;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Assessment
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Information { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
    }
}
