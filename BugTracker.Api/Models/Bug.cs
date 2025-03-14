using System.ComponentModel.DataAnnotations.Schema;
using BugTracker.Api.Models.Common;
using BugTracker.Api.Models.Enum;

namespace BugTracker.Api.Models;

public class Bug : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? UpdatedDate { get; set; }
    public BugStatus Status { get; set; } // Open, In Progress, Resolved, Closed
    public BugPriority Priority { get; set; } // Low, Medium, High, Critical

    [ForeignKey("AssignedToId")]
    public int AssignedToId { get; set; }
    public User? AssignedTo { get; set; }

    [ForeignKey("ProjectId")]
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
}
