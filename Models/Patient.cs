using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Patient : User
    {
        public DateTime? BirthDate { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
