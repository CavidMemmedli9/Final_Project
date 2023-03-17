using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public SliderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Slider slider = _appDbContext.Slider.FirstOrDefault();

            return View(await Task.FromResult(slider));
        }


    }
}
