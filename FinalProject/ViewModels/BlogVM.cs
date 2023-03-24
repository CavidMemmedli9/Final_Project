using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class BlogVM
    {
        public List<Category> Category { get; set; }

        public List<Job> Job { get; set; }

        public List<Comment> Comment { get; set; }


        public Blog Blog { get; set; }
        public List<Articles> Articles { get; set; }
    }
}