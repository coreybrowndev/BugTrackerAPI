using BugTracker.Api.Contracts;
using BugTracker.Api.Models.Common;
using BugTracker.Api.Models.Enum;
namespace BugTracker.Api.Models.DomainModels;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; } // admin, developer, QA, PM

    // Many to Many relationship with Project
    public ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    // Single user can have multiple bugs assigned and reported
    public ICollection<Bug> AssignedBugs { get; set; } = new List<Bug>();
    public ICollection<Bug> ReportedBugs { get; set; } = new List<Bug>();
}