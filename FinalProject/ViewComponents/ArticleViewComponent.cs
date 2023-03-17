using FinalProject.DAL;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.ViewComponents
{
    public class ArticleViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public ArticleViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Articles> Articles = _appDbContext.Articles.ToList();
            return View(await Task.FromResult(Articles));
        }

    }
}
