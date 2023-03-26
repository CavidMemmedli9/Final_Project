using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }

        public int Hours { get; set; }
        
        public string Days { get; set; }
        public DateTime CreatedTime { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
        public bool IsDeleted { get; set; }
        public List<Photos> Photos { get; set; }

    }
}
