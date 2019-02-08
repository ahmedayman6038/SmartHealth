using System;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class DoctorRating
    {
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        [Required]
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime SendDate { get; set; }
    }
}
