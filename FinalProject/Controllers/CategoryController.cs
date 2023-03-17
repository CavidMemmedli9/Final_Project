using FinalProject.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Cleaning_Services = _context.Cleaning_Services.FirstOrDefault();
            categoryVM.Category = _context.Category.ToList();
            categoryVM.Person = _context.Person.ToList();

            return View(categoryVM);
        }
    }
}
