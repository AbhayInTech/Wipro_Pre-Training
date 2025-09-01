// Here i create a db context class for subject model and student model
using Microsoft.EntityFrameworkCore;
using SMD_Backend.Models;
namespace SMD_Backend.Data
{
    public class DataDBContext : DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        {

        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}