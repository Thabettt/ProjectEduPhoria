// Models/Instructor.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        public string ExpertiseArea { get; set; }

        public string LatestQualification { get; set; }

        [ForeignKey("Email")]
        public virtual Users EmailNavigation { get; set; }
    }
}