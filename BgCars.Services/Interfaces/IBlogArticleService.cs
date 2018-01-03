namespace BgCars.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IBlogArticleService
    {
        Task CreateAsync(string title, string content, string thumbnailUrl, string authorId);

        Task EditAsync(int id, string title, string content, string thumbnailUrl);

        Task DeleteAsync(int id);
    }
}
