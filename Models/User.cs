using System;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedData { get; set; }
    }
}
