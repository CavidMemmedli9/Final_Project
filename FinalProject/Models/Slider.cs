using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
