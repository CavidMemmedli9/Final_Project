namespace FinalProject.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Job> Job { get; set; }
    }
}
