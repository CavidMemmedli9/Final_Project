using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,Moderator")]
    public class JobController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public JobController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var jobs = _appDbContext.JobInfo.Include(c=>c.Category).Include(t=>t.City).ToList();
            _appDbContext.SaveChanges();

            return View(jobs);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category.ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_appDbContext.City.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(JobInfo job)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category.ToList(), "Id", "Name");

            ViewBag.City = new SelectList(_appDbContext.City.ToList(), "Id", "Name");


            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!job.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "sekil sec");
            }
            if (job.Photo.CheckImageSize(1000))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur");
            }



            JobInfo newJobInfo = new JobInfo();
            newJobInfo.ImageUrl = job.Photo.SaveImage(_env, "assets/images/popular-categories");
            newJobInfo.JobDesc = job.JobDesc;
            newJobInfo.Company = job.Company;
            newJobInfo.Skill = job.Skill;
            newJobInfo.Title = job.Title;
            newJobInfo.Price = job.Price;
            newJobInfo.EmailAddress = job.EmailAddress;
            newJobInfo.Work = job.Photo.SaveImage(_env, "assets/images/providers");
            newJobInfo.CategoryId = job.CategoryId;
            newJobInfo.CityId = job.CityId;
            _appDbContext.JobInfo.Add(newJobInfo);
            _appDbContext.SaveChanges();
            return View();

        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            JobInfo job = _appDbContext.JobInfo.Find(id);
            if (job == null) return NotFound();

            //string path = Path.Combine(_env.WebRootPath + "/img" + category.ImageUrl);
            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            _appDbContext.JobInfo.Remove(job);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category.ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_appDbContext.City.ToList(), "Id", "Name");

            if (id == null) return NotFound();
            JobInfo job = _appDbContext.JobInfo.Find(id);
            if (job == null) return NotFound();
            return View(new UpdateJobVM { JobDesc = job.JobDesc, Company = job.Company, Skill = job.Skill,  CityId = job.CityId, CategoryId = job.CategoryId, ImageUrl = job.ImageUrl, Title = job.Title, Price = job.Price, Work = job.Work, EmailAddress = job.EmailAddress, });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateJobVM job)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Category.ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_appDbContext.City.ToList(), "Id", "Name");


            if (id == null) return NotFound();
            JobInfo existJob = _appDbContext.JobInfo.Find(id);
            if (existJob == null) return NotFound();
            string filename = null;

            if (job.Photo != null)
            {
                string path = Path.Combine(_env.WebRootPath, "assets/images/popular-categories", existJob.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (!job.Photo.CheckImage())
                {
                    ModelState.AddModelError("Photo", "sekil sec");
                }
                if (job.Photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photo", "olcu boyukdur");

                }
                filename = job.Photo.SaveImage(_env, "assets/images/popular-categories");

            }
            existJob.ImageUrl = filename ?? existJob.ImageUrl;
            existJob.JobDesc = job.JobDesc;
            existJob.Company = job.Company;
            existJob.Skill = job.Skill;
            existJob.Price = job.Price;
            existJob.EmailAddress = job.EmailAddress;
            existJob.CategoryId = job.CategoryId;
            existJob.CityId = job.CityId;
            existJob.Title = job.Title;



            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
