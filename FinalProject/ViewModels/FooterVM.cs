using FinalProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FinalProject.ViewModels
{
    public class FooterVM
    {
        public List<Category> Category { get; set; }

        public City City { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match ")]
        [Display(Name = "Repeat Password")]
        public string PasswordConfirm { get; set; }

        public List<Settings> Settings { get; set; }
    }
}
