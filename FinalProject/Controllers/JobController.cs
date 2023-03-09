using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
