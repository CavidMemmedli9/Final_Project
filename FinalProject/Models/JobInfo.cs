using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class JobInfo
    {
        public int Id { get; set; }
        public string JobDesc { get; set; }

        public string KeyResponse { get; set; }

        public string Skill { get; set; }
        public string Location { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public int Price { get; set; }
        public string Work { get; set; }

        public Vacancy Vacancy { get; set; }
        public int VacancyId { get; set; }

    }
}
