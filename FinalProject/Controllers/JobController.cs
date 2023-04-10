using FinalProject.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalProject.Controllers
{
   
    public class JobController : Controller
    {
        private readonly AppDbContext _context;

        public JobController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? cityid,int? categoryid,int? maxprice)
        {
            var query = _context.JobInfo.Include(j=>j.Category).Include(x=>x.City).AsQueryable();
            JobVM jobVM = new JobVM();
            if (categoryid != null)
            {
                query = query.Where(j=>j.CategoryId == categoryid);
            }
            if (cityid != null)
            {
                query = query.Where(j => j.CityId == cityid);
            }
            if (maxprice != null)
            {
                query = query.Where(q => q.Price <= maxprice);
            }

            jobVM.JobInfo = query.ToList();
            jobVM.Background = _context.Background.FirstOrDefault();
           

            jobVM.City = _context.City.ToList();
            jobVM.Category = _context.Category.ToList();
            return View(jobVM);
        }

        public IActionResult JobDetail(int Id,int? cityid)
        {
            var data = _context.JobInfo.FirstOrDefault(p => p.Id == Id);
            if (data == null)
            {
                return RedirectToAction("Index", "job");
            }
            return View(data);
        }
    }
}