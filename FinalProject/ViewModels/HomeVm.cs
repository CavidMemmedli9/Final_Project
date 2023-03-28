using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class HomeVM
    {
        public Slider Slider { get; set; }
        public List<Category> Category { get; set; }

        public List<City> City { get; set; }

        public List<Statics> Statics { get; set; }

        public List<Articles> Articles { get; set; }

        public List<Choose> Choose { get; set; }
    }
}
