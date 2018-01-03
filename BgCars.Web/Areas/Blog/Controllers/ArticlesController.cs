namespace BgCars.Web.Areas.Blog.Controllers
{
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Html;
    using Services.Interfaces;
    using System.Threading.Tasks;

    [Area(WebConstants.BlogArea)]
    [Authorize(Roles = WebConstants.BlogAuthorRole)]
    public class ArticlesController : Controller
    {
        private readonly IBlogArticleService articles;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public ArticlesController(IBlogArticleService articles, 
                                  UserManager<User> userManager,
                                  IHtmlService html)
        {
            this.articles = articles;
            this.userManager = userManager;
            this.html = html;
        }

        //GET: /blog/articles/create
        public IActionResult Create() => View();


        //POST: /blog/articles/create
        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(ArticleFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, model.ThumbnailUrl, userId);

            return RedirectToAction(
                nameof(Create),
                new { area = string.Empty });
        }
    }
}
