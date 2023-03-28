﻿namespace FinalProject.Models
{
    public class JobInfo
    {
        public int Id { get; set; }
        public string JobDesc { get; set; }

        public string KeyResponse { get; set; }

        public string Skill { get; set; }
        public string Location { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public string Price { get; set; }

        public Vacancy Vacancy { get; set; }
        public int VacancyId { get; set; }

    }
}
