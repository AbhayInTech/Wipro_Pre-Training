// here i declare the properties of the student class
namespace SMD_Backend.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        // adding foreign key property to link with Subject
        public Subject Subject { get; set; }

    }
}