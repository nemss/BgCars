namespace BgCars.Services.Models.Articles
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class ArticlesListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [MinLength(ArticleTitleMinLenght)]
        [MaxLength(ArticleThumbnailMaxLenght)]
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string ThumbnailUrl { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticlesListingServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
