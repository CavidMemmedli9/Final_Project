using FinalProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Detail(int Id)
        {
            var blog=_context.Articles.Include(t => t.Blog).FirstOrDefault(p => p.BlogId ==Id);
            return View(blog);
        }
    }
}
