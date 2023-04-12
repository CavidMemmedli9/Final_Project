﻿using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class StaticViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public StaticViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.AcCount = _appDbContext.Users.ToList().Count;
            ViewBag.JobCount = _appDbContext.JobInfo.ToList().Count;
            return View();
        }
    }
}
