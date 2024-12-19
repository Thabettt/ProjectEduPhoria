// Models/Learner.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class Learner
    {
        [Key]
        public int LearnerId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Country { get; set; }

        public string CulturalBackground { get; set; }

        public string Gender { get; set; }

        [ForeignKey("Email")]
        public virtual Users EmailNavigation { get; set; }
    }
}