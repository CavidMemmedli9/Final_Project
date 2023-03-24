namespace FinalProject.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime CreatedTime { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
