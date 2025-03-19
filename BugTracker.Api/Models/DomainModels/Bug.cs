using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Api.Models.Common;
using BugTracker.Api.Models.Enum;
namespace BugTracker.Api.Models.DomainModels;
public class Bug : BaseEntity
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public BugStatus Status { get; set; } // Open, In Progress, Resolved, Closed
    public BugPriority Priority { get; set; } // Low, Medium, High, Critical

    // Foreign Key: The user who reported this bug
    public int ReporterId { get; set; }
    public required User Reporter { get; set; }// Required: Every bug must have a reporter

    // Foreign Key: The user assigned to fix this bug (Optional)
    public int? AssignedToId { get; set; } = null;
    public User? AssignedTo { get; set; } = null;

    // Foreign Key: This bug belongs to a single project
    public int ProjectId { get; set; }
    public required Project Project { get; set; }


}
