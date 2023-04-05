using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class JobVM
    {
        public Background Background { get; set; }

        public List<JobInfo> JobInfo { get; set; }

        public List<City> City { get; set; }
        public List<Category> Category { get; set; }
    }
}
