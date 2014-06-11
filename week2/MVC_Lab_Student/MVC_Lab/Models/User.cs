using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Lab.Models
{

    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Real name")]
        public string RealName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<User> TrustedUsers { get; set; }
        public virtual ICollection<User> TrustedByUsers { get; set; } 
    }
}