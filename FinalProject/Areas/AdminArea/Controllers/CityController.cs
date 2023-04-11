using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,Moderator")]

    public class CityController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;
        public CityController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            var city = _appDbContext.City.ToList();
            _appDbContext.SaveChanges();
            return View(city);
        }
    
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(City city)
        {
            if (!ModelState.IsValid) return View();

            var isExist = _appDbContext.City
                .Any(c => c.Name.ToLower() == city.Name.ToLower());

            if (isExist)
            {
                ModelState.AddModelError("Name", "this name already exist");
                return View();
            }

            City newCity = new City();
            newCity.Name = city.Name;

            _appDbContext.City.Add(city);

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            City city = _appDbContext.City.Find(id);
            if (city == null) return NotFound();
            return View(new UpdateCityVM {  Name = city.Name });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateCityVM city)
        {
            if (id == null) return NotFound();
            City existCity = _appDbContext.City.Find(id);
            if (existCity == null) return NotFound();
            

            existCity.Name = city.Name;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            City city = _appDbContext.City.Find(id);

            if (city == null) return NotFound();

          
            _appDbContext.City.Remove(city);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
