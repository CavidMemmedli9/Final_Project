using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public int Phone { get; set; }
   
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
