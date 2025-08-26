using Microsoft.EntityFrameworkCore;
using EF_DB_Connect_Demo.Modules;
using EF_DB_Connect_Demo.Data;
using System.Linq;

namespace EF_DB_Connect_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrainingContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-6IO1N8R8\\SQLEXPRESS02;Initial Catalog=EF_Demo;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            using (var context = new TrainingContext(optionsBuilder.Options))
            {
                try
                {
                    // Ensure database is created
                    context.Database.EnsureCreated();

                    if (!context.Students.Any())
                    {
                        var trainer = new Trainer { TrainerName = "Salman Khan", Expertise = "Driving Instructor" };
                        var course = new Course { CourseName = "Advanced Driving Course", Trainer = trainer };
                        var student = new Student { StudentName = "Rahul Sharma", Age = 25, Course = course };

                        context.Trainers.Add(trainer);
                        context.Courses.Add(course);
                        context.Students.Add(student);
                        context.SaveChanges();
                        Console.WriteLine("Sample data inserted!");
                    }
                    else
                    {
                        Console.WriteLine("Database already has data.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Please check your SQL Server connection and ensure the instance is running.");
                }
            }
        }
    }
}