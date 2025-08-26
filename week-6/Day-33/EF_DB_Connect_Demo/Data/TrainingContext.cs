using Microsoft.EntityFrameworkCore;
using EF_DB_Connect_Demo.Modules;

namespace EF_DB_Connect_Demo.Data
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } // Db context class is the bridge between the database and the application
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships if needed
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany()
                .HasForeignKey(s => s.CourseID);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Trainer)
                .WithMany()
                .HasForeignKey(c => c.TrainerID);
        }
    }
}
