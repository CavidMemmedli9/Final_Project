using FinalProject.DAL;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public FooterViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footerVM = new FooterVM();
           

            footerVM.Category = _appDbContext.Category.ToList();
            footerVM.City = _appDbContext.City.ToList();
            footerVM.Settings = _appDbContext.Settings.ToList();
            return View(await Task.FromResult(footerVM));
        }
    }
}
