using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class HealthRecord
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Patient Patient { get; set; }
    }
}
