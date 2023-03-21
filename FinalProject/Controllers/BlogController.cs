using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
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
     
        public async Task<IActionResult> Index()
        {
            ArticlesVM model = new();
            model.Categories = await _context.Category.ToListAsync();
            model.Articles = await _context.Articles.OrderByDescending(p=>p.Id).ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Search(string item)
        {
            List<Articles> blog = new();
            if (item != null && item.Length > 1)
            {
                blog = await _context.Articles.Where(c => c.Title.ToLower().Contains(item.ToLower())).ToListAsync();
            }
            return PartialView("_SearchPartial", blog);
        }

        public IActionResult Detail(int id)
        {
            var blog = _context.Articles.Include(t => t.Blog).FirstOrDefault(p => p.Id == id);
            return View(blog);
        }
    }
}
