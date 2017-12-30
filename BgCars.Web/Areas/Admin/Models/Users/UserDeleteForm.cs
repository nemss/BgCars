namespace BgCars.Web.Areas.Admin.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserDeleteForm
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
