using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class ProfileVM
    {
        public Slider Slider { get; set; }

        public List<About> About { get; set; }

        public Quote Quote { get; set; }

        public List<Articles> Articles { get; set; }

        public List<Provider> Provider { get; set; }


        public List<Related_Provider> Related_Provider { get; set; }

        public List<News_Articles> News_Articles { get; set; }

        public AboutProvider AboutProvider { get; set; }

    }
}
