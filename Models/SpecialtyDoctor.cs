namespace SmartHealth.Models
{
    public class SpecialtyDoctor
    {
        public int SpecialtyID { get; set; }
        public Specialty Specialty { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
