using System;

namespace SmartHealth.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
    }
}
