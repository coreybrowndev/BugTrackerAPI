using BugTracker.Api.Models.DomainModels;
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
    public DbSet<ProjectUser> ProjectUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Many to Many relationship between User and Project
        modelBuilder.Entity<ProjectUser>()
            .HasKey(pu => new { pu.ProjectId, pu.UserId }); // composite key

        modelBuilder.Entity<ProjectUser>()
        .HasOne(pu => pu.User)
        .WithMany(u => u.ProjectUsers)
        .HasForeignKey(pu => pu.UserId);

        modelBuilder.Entity<ProjectUser>()
        .HasOne(pu => pu.Project)
        .WithMany(p => p.ProjectUsers)
        .HasForeignKey(pu => pu.ProjectId);

        modelBuilder.Entity<Bug>()
        .HasOne(b => b.Project)
        .WithMany(p => p.Bugs)
        .HasForeignKey(b => b.ProjectId)
        .OnDelete(DeleteBehavior.Cascade); // Delete bugs when a project is deleted

        modelBuilder.Entity<Bug>()
        .HasOne(b => b.Reporter)
        .WithMany(u => u.ReportedBugs)
        .HasForeignKey(b => b.ReporterId)
        .OnDelete(DeleteBehavior.Restrict); // Restrict deleting a user if they have reported bugs

        // User → Bug (One-to-Many: Assigned Developer)
        modelBuilder.Entity<Bug>()
        .HasOne(b => b.AssignedTo)
        .WithMany(u => u.AssignedBugs)
        .HasForeignKey(b => b.AssignedToId)
        .OnDelete(DeleteBehavior.SetNull); // Allow unassigning a bug from a user


        // <summary>
        // Convert enum to string for UserRole
        // </summary>
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<Bug>()
            .Property(b => b.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Bug>()
            .Property(b => b.Priority)
            .HasConversion<string>();
    }
}