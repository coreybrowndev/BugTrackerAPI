using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Api.Models.Common;
namespace BugTracker.Api.Models.DomainModels;
public class Project : BaseEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;

    // Many-to-Many with User
    public ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    // One-to-Many: Project has multiple Bugs
    public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
}