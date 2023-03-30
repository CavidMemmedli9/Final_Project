using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class JobVM
    {
        public Background Background { get; set; }

        public List<JobInfo> JobInfo { get; set; }
        public List<Vacancy> Vacancy { get; set; }


    }
}
