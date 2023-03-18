using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ulong Number { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
