using System.Collections.Generic;

namespace SmartHealth.Models
{
    public class Doctor : User
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string Information { get; set; }
        public ICollection<SpecialtyDoctor> SpecialtyDoctors { get; set; }
        public ICollection<DoctorRating> DoctorRatings { get; set; }
    }
}
