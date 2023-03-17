using FinalProject.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM();
            aboutVM.Slider = _context.Slider.FirstOrDefault();
            aboutVM.About = _context.About.FirstOrDefault();
            aboutVM.Statics = _context.Statics.FirstOrDefault();

            aboutVM.Background = _context.Background.FirstOrDefault();
            return View(aboutVM);
        }
    }
}
