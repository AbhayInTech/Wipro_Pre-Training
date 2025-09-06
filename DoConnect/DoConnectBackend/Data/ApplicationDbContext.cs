using DoConnectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DoConnectBackend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<Image> Images => Set<Image>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.Entity<User>().HasIndex(u => u.Username).IsUnique();

        b.Entity<Question>()
            .HasOne(q => q.User).WithMany(u => u.Questions).HasForeignKey(q => q.UserId);

        b.Entity<Answer>()
            .HasOne(a => a.User).WithMany(u => u.Answers).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.NoAction);

        b.Entity<Answer>()
            .HasOne(a => a.Question).WithMany(q => q.Answers).HasForeignKey(a => a.QuestionId);

        b.Entity<Image>()
            .HasOne(i => i.Question).WithMany(q => q.Images).HasForeignKey(i => i.QuestionId).OnDelete(DeleteBehavior.NoAction);

        b.Entity<Image>()
            .HasOne(i => i.Answer).WithMany(a => a.Images).HasForeignKey(i => i.AnswerId).OnDelete(DeleteBehavior.NoAction);
    }
}
