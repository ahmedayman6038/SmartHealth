using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Specialty
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public ICollection<SpecialtyDoctor> SpecialtyDoctors { get; set; }
    }
}
