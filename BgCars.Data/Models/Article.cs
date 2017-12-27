namespace BgCars.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ArticleTitleMinLenght)]
        [MaxLength(ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(ArticleContentMinLenght)]
        public string Content { get; set; }

        [Required]
        [MaxLength(ArticleThumbnailMaxLenght)]
        public string ThumbnailUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
