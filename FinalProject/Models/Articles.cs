using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Articles
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }


    }
}
