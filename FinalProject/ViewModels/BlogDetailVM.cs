using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class BlogDetailVM
    {
        public List<Articles> Articles { get; set; }

        public List<Category> Category { get; set; }

        public List<Comment> Comment { get; set; }

        public List<Blog> Blog { get; set; }
        public AppUser AppUser { get; set; }
    }
}
