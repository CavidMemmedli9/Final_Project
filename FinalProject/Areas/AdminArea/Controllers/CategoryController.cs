using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]

    [Authorize(Roles = "Admin,Moderator")]

    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var categories = _appDbContext.Category.ToList();
            _appDbContext.SaveChanges();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!category.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "sekil sec");
            }
            if (category.Photo.CheckImageSize(1000))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur");
            }



            Category newcategory = new Category();
            newcategory.ImageUrl = category.Photo.SaveImage(_env, "assets/images/popular-categories");
            newcategory.Name = category.Name;
            _appDbContext.Category.Add(newcategory);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
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
