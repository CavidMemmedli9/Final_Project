using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
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
            newJobInfo.KeyResponse = job.KeyResponse;
            newJobInfo.Skill = job.Skill;
            newJobInfo.Location = job.Location;
            newJobInfo.Title = job.Title;
            newJobInfo.Price = job.Price;
            newJobInfo.CategoryId = job.CategoryId;
            newJobInfo.CityId = job.CityId;
            _appDbContext.JobInfo.Add(newJobInfo);
            _appDbContext.SaveChanges();
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Category.Find(id);
            if (category == null) return NotFound();

            //string path = Path.Combine(_env.WebRootPath + "/img" + category.ImageUrl);
            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            _appDbContext.Category.Remove(category);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Category.Find(id);
            if (category == null) return NotFound();
            return View(new UpdateCategoryVM { Name = category.Name });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateCategoryVM category)
        {
            if (id == null) return NotFound();
            Category existCategory = _appDbContext.Category.Find(id);
            if (existCategory == null) return NotFound();
            string filename = null;

            if (category.Photo != null)
            {
                string path = Path.Combine(_env.WebRootPath, "assets/images/popular-categories", existCategory.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (!category.Photo.CheckImage())
                {
                    ModelState.AddModelError("Photo", "sekil sec");
                }
                if (category.Photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photo", "olcu boyukdur");

                }
                filename = category.Photo.SaveImage(_env, "assets/images/popular-categories");

            }
            existCategory.ImageUrl = filename ?? existCategory.ImageUrl;
            existCategory.Name = category.Name;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
