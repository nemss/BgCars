namespace BgCars.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Articles;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ArticleService : IArticleService
    {
        private readonly BgCarsDbContext db;

        public ArticleService(BgCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArticlesListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Articles
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * ServiceConstants.ArticlesPageSize)
                .Take(ServiceConstants.ArticlesPageSize)
                .ProjectTo<ArticlesListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db.Articles.CountAsync();

        public async Task<IEnumerable<ArticlesListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Articles
                .OrderByDescending(c => c.Id)
                .Where(c => c.Title.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<ArticlesListingServiceModel>()
                .ToListAsync();
        }

        public async Task<ArticlesListingServiceModel> ById(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticlesListingServiceModel>()
                .FirstOrDefaultAsync();
    }
}
