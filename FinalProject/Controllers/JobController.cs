using FinalProject.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;

        public JobController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            JobVM jobVM = new JobVM();
            jobVM.Vacancy = _context.Vacancy.ToList();
            jobVM.Background = _context.Background.FirstOrDefault();
            return View(jobVM);
        }

        public IActionResult JobDetail(int Id)
        {
            var data = _context.JobInfo.Include(t => t.Vacancy).FirstOrDefault(p => p.VacancyId == Id);
            if (data == null)
            {
                return RedirectToAction("Index", "job");
            }
            return View(data);
        }
    }
}
