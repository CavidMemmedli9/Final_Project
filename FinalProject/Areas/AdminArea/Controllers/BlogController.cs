using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.AdminArea.Controllers
{
 
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        
        }
        public IActionResult Index()
        {
            var blog= _appDbContext.Blog.ToList();
            _appDbContext.SaveChanges();
            return View(blog);
        }

    }
}
