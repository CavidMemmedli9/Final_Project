using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
