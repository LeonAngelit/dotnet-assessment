using Microsoft.EntityFrameworkCore;
using apiNET.Models;

namespace apiNET;

public class QuestionaryContext : DbContext
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<User> Users { get; set; }

    public QuestionaryContext(DbContextOptions<QuestionaryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Question>(question =>
        {
            question.ToTable("questions");
            question.HasKey(p => p.Id);
            question.Property(p => p.Title).IsRequired().HasMaxLength(150);
            question.Property(p => p.Subject).IsRequired();
            question.Property(p => p.Options).IsRequired();

        });



        modelBuilder.Entity<User>(user =>
        {
            user.ToTable("users");
            user.HasKey(p => p.Id);
            user.Property(p => p.email).IsRequired().HasMaxLength(60);
            user.Property(p => p.results).IsRequired();

        });
    }
}
