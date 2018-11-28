namespace SmartHealth.Models
{
    public class SymptomDisease
    {
        public int SymptomID { get; set; }
        public Symptom Symptom { get; set; }
        public int DiseaseID { get; set; }
        public Disease Disease { get; set; }
    }
}
