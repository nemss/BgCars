namespace BgCars.Web.Areas.Blog.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class ArticleFormModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ArticleTitleMinLenght)]
        [MaxLength(ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [MaxLength(ArticleThumbnailMaxLenght)]
        public string ThumbnailUrl { get; set; }

        [Required]
        [MinLength(ArticleContentMinLenght)]
        public string Content { get; set; }
    }
}
