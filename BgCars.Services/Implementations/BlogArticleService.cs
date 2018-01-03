namespace BgCars.Services.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    public class BlogArticleService : IBlogArticleService
    {
        private readonly BgCarsDbContext db;

        public BlogArticleService(BgCarsDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string title, string content, string thumbnailUrl, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                ThumbnailUrl = thumbnailUrl,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            await this.db.AddAsync(article);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string content, string thumbnailUrl)
        {
            var articleById = await this.db.Articles.FindAsync(id);

            if (articleById == null)
            {
                return;
            }

            articleById.Title = title;
            articleById.Content = content;
            articleById.ThumbnailUrl = thumbnailUrl;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var articleById = await this.db.Articles.FindAsync(id);

            if (articleById == null)
            {
                return;
            }

            this.db.Remove(articleById);
            await this.db.SaveChangesAsync();
        }
    }
}
