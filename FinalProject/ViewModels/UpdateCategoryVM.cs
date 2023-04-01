using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.ViewModels
{
    public class UpdateCategoryVM
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
