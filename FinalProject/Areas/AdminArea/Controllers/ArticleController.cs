using FinalProject.DAL;
using FinalProject.Helpers.Extension;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalProject.Areas.AdminArea.Controllers
{

    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]

    public class ArticleController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;
        public ArticleController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            var article = _appDbContext.Articles.ToList();
            _appDbContext.SaveChanges();
            return View(article);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Articles article)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!article.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "sekil sec");
            }
            if (article.Photo.CheckImageSize(1000))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur");
            }



            Articles newarticle = new Articles();
            newarticle.ImageUrl = article.Photo.SaveImage(_env, "assets/images/popular-categories");
            newarticle.Desc = article.Desc;
            newarticle.Title = article.Title;
            _appDbContext.Articles.Add(newarticle);
            _appDbContext.SaveChanges();
            return View();
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Articles article = _appDbContext.Articles.Find(id);
            if (article == null) return NotFound();
            return View(new UpdateArticlesVM { ImageUrl = article.ImageUrl, Desc = article.Desc, Title = article.Title });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateArticlesVM article)
        {
            if (id == null) return NotFound();
            Articles existArticle = _appDbContext.Articles.Find(id);
            if (existArticle == null) return NotFound();
            string filename = null;

            if (article.Photo != null)
            {
                string path = Path.Combine(_env.WebRootPath, "assets/images/popular-categories", existArticle.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (!article.Photo.CheckImage())
                {
                    ModelState.AddModelError("Photo", "sekil sec");
                }
                if (article.Photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photo", "olcu boyukdur");

                }
                filename = article.Photo.SaveImage(_env, "assets/images/popular-categories");

            }

            existArticle.ImageUrl = filename ?? existArticle.ImageUrl;
            existArticle.Desc = article.Desc;
            existArticle.Title = article.Title;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Articles articles = _appDbContext.Articles.Find(id);
            if (articles == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath + "img" + articles.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _appDbContext.Articles.Remove(articles);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
