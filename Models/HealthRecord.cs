namespace SmartHealth.Models
{
    public class HealthRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
    }
}
