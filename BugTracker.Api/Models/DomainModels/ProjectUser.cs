namespace BugTracker.Api.Models.DomainModels;
public class ProjectUser
{
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}