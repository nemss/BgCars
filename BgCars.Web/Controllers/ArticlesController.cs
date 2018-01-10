namespace BgCars.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Services.Interfaces;
    using System.Threading.Tasks;

    public class ArticlesController : Controller
    {
        private readonly IArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IArticleService articles,
                                  UserManager<User> userManager)
        {
            this.articles = articles;
            this.userManager = userManager;
        }

        //GET: /articles/
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });

        //GET: /articles/details
        public async Task<IActionResult> Details(int id)
        {
            var articleFindById = await this.articles.ById(id);

            if (articleFindById == null)
            {
                return NotFound();
            }

            return this.View(articleFindById);
        }
    }
}
