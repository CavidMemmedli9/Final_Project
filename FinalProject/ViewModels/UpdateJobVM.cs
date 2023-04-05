using FinalProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.ViewModels
{
    public class UpdateJobVM
    {
        public string JobDesc { get; set; }

        public string Company { get; set; }

        public string Skill { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Work { get; set; }

    }
}
