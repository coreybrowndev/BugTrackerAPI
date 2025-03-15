using BugTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace BugTracker.Api.Database;

public class BugTrackerDbContext : DbContext
{
    public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<Bug> Bugs { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // <summary>
        // Convert enum to string for UserRole
        // </summary>
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }
}