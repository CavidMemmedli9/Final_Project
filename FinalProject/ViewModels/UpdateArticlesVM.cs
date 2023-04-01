using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.ViewModels
{
    public class UpdateArticlesVM
    {

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
