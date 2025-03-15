namespace BugTracker.Api.Models;

using BugTracker.Api.Contracts;
using BugTracker.Api.Models.Common;
using BugTracker.Api.Models.Enum;
using Microsoft.AspNetCore.Identity;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string passwordHash { get; set; } = string.Empty;
    public UserRole Role { get; set; } // admin, developer, QA, PM
    public ICollection<Bug> AssignedBugs { get; set; } = new List<Bug>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}