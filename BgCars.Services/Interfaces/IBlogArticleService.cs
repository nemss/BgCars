namespace BgCars.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.Blog;

    public interface IBlogArticleService
    {
        Task CreateAsync(string title, string content, string thumbnailUrl, string authorId);

        Task EditAsync(int id, string title, string content, string thumbnailUrl);

        Task DeleteAsync(int id);

        Task<BlogArticleDetailsServiceModel> ById(int id);
    }
}
