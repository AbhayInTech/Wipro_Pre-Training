using System.ComponentModel.DataAnnotations;

namespace EF_DB_Connect_Demo.Modules
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100)]
        public required string StudentName { get; set; }
        public int Age { get; set; }
        public int CourseID { get; set; } // Foreign key
        public Course? Course { get; set; } // Navigation property
    }
}