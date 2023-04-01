using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public List<Job> Job { get; set; }
    }
}
