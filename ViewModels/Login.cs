using System.ComponentModel.DataAnnotations;

namespace SmartHealth.ViewModels
{
    public class Login
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
