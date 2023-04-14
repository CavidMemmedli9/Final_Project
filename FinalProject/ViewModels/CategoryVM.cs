using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class CategoryVM
    {
        public Cleaning_Services Cleaning_Services { get; set; }

        public List<Category> Category { get; set; }

        public List<People> People { get; set; }
    }
}
