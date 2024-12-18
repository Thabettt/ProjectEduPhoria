using System.ComponentModel.DataAnnotations;

namespace MainApp.Models
{
    public class Users
    {
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // ASP.NET Identity will manage the PasswordHash
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Learner Learner { get; set; }
    }
}