namespace FinalProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> Childs { get; set; }
    }
}
