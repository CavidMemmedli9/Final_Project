namespace FinalProject.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public List<JobInfo> JobInfo { get; set; }
    }
}
