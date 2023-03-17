using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public CategoryViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> Category = _appDbContext.Category.ToList();
            return View(await Task.FromResult(Category));
        }

    }
}
