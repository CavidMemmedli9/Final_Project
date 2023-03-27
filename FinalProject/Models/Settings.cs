using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Settings
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public int Number { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }


    }
}
