using FinalProject.DAL;
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
            List<Statics> Statics = _appDbContext.Statics.ToList();
            return View(await Task.FromResult(Statics));
        }
    }
}
