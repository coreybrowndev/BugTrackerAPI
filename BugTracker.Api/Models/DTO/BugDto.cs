using BugTracker.Api.Models.Enum;

namespace BugTracker.Api.Models.DTO;

//<summary>
//Data Transfer Object for Bug
//</summary>
public class BugDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public BugStatus Status { get; set; }
    public BugPriority Priority { get; set; }
    public int AssignedToId { get; set; }
    public int ProjectId { get; set; }
}