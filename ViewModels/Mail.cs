using System.ComponentModel.DataAnnotations;

namespace SmartHealth.ViewModels
{
    public class Mail
    {
        [Required]
        [EmailAddress]
        public string Reciever { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
