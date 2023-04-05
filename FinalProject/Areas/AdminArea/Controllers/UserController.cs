using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Areas.AdminArea.Controllers
{
    public class UserController : Controller
    {
        //[Area("AdminArea")]
        //public IActionResult Index()
        //{

        //    return View();
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[AutoValidateAntiforgeryToken]
        //public IActionResult Create()
        //{


        //    if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
        //    {
        //        return View();
        //    }
        //    if (!Photo.CheckImage())
        //    {
        //        ModelState.AddModelError("Photo", "sekil sec");
        //    }
        //    if (Photo.CheckImageSize(1000))
        //    {
        //        ModelState.AddModelError("Photo", "olcu boyukdur");
        //    }



        //    JobInfo newJobInfo = new JobInfo();
        //    newJobInfo.ImageUrl = job.Photo.SaveImage(_env, "assets/images/popular-categories");
        //    newJobInfo.JobDesc = job.JobDesc;
        //    newJobInfo.Company = job.Company;
        //    newJobInfo.Skill = job.Skill;
        //    newJobInfo.Title = job.Title;
        //    newJobInfo.Price = job.Price;
        //    newJobInfo.Work = job.Photo.SaveImage(_env, "assets/images/providers");
        //    newJobInfo.CategoryId = job.CategoryId;
        //    newJobInfo.CityId = job.CityId;
        //    _appDbContext.JobInfo.Add(newJobInfo);
        //    _appDbContext.SaveChanges();
        //    return View();

        //}
    
    }
}
