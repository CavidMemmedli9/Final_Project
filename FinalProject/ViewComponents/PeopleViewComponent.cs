using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class PeopleViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public PeopleViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var people=_appDbContext.People.ToList();

            return View(await Task.FromResult(people));
        }

    }
}
