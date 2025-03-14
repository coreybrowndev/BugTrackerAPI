namespace BugTracker.Api.Models;

using BugTracker.Api.Models.Common;
using BugTracker.Api.Models.Enum;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }  // Admin Developer QA PM
    public ICollection<Bug> AssignedBugs { get; set; } = new List<Bug>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}