using FinalProject.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           return View(_appDbContext.Contact.ToList().Count);
        }
    }
}
