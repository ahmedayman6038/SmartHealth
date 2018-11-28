using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Symptom
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<SymptomDisease> SymptomDiseases { get; set; }
    }
}
