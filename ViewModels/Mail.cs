using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
