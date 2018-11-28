using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Disease
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public Specialty Specialty { get; set; }
        public ICollection<SymptomDisease> SymptomDiseases { get; set; }
    }
}
