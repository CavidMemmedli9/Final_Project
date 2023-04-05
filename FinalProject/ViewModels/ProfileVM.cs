using FinalProject.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class ProfileVM
    {
        public Slider Slider { get; set; }

        public List<About> About { get; set; }

        public List<Category> Category { get; set; }

        public List<Quote> Quote { get; set; }

        public List<Articles> Articles { get; set; }

        public List<Provider> Provider { get; set; }


        public List<Settings> Settings { get; set; }
        public List<Related_Provider> Related_Provider { get; set; }

        public List<News_Articles> News_Articles { get; set; }

        public AboutProvider AboutProvider { get; set; }
        public string Name { get; set; }

        public string EmailAddress { get; set; }
        public int Phone { get; set; }

        public string Message { get; set; }

    }
}
