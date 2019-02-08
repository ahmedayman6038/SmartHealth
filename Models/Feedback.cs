using System;
using System.ComponentModel.DataAnnotations;

namespace SmartHealth.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public Patient Patient { get; set; }
    }
}
