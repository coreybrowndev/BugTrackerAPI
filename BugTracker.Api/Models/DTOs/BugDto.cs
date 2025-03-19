using BugTracker.Api.Models.Enum;
namespace BugTracker.Api.Models.DTOs;

//<summary>
//Data Transfer Object for Bug
//</summary>
public class BugDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public BugStatus Status { get; set; }
    public BugPriority Priority { get; set; }
    public int AssignedToId { get; set; }
    public int ProjectId { get; set; }
}