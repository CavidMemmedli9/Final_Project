using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
       private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.Slider = _context.Slider.FirstOrDefault();
            homeVM.Articles= _context.Articles.ToList();
            homeVM.Choose = _context.Choose.ToList();
            homeVM.Statics = _context.Statics.ToList();
            return View(homeVM);
        }
        
    }
}