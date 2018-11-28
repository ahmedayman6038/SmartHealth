using System;

namespace SmartHealth.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
