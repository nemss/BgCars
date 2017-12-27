namespace BgCars.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(UserNameMinLenght)]
        [MaxLength(UserNameMaxLenght)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
