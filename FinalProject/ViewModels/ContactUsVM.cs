using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class ContactUsVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public int Phone { get; set; }
        public string Subject { get; set; }

        public string? Response { get; set; }
    }
}
