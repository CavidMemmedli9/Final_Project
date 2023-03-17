using FinalProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class ChooseViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public ChooseViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Choose = _appDbContext.Choose.ToList();

            return View(await Task.FromResult(Choose));
        }
    }
}
