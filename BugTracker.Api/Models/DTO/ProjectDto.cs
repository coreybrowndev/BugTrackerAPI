namespace BugTracker.Api.Models.DTO;

//<summary>
//Data Transfer Object for Project
//</summary>
public class ProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<BugDto> Bugs { get; set; } = new List<BugDto>();
}