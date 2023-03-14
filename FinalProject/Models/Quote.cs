using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Quote
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public int Phone { get; set; }

        public string Message { get; set; }
    }
}
