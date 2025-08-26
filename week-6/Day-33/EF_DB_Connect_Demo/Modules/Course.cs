using System.ComponentModel.DataAnnotations;

namespace EF_DB_Connect_Demo.Modules
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(100)]
        public required string CourseName { get; set; }
        public int TrainerID { get; set; } // Duration in hours
        public Trainer? Trainer { get; set; } // Navigation property
    }
}