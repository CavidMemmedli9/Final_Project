using FinalProject.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ProfileVM profileVM = new ProfileVM();
            profileVM.Slider = _context.Slider.FirstOrDefault();
            profileVM.AboutProvider = _context.AboutProvider.FirstOrDefault();
            profileVM.News_Articles = _context.News_Articles.ToList();

            profileVM.Related_Provider = _context.Related_Provider.ToList();
            return View(profileVM);
        }
    }
}
