namespace FinalProject.Models
{
    public class Photos
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int JobId { get; set; }

    }
}
