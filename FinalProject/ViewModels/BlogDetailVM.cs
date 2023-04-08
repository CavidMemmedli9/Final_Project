using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class BlogDetailVM
    {
        public Articles Articles { get; set; }
        public List<Category> Categories { get; set; }

        //public Blog Blog { get; set; }

        public List<Comment> Comment { get; set; }
    }
}
