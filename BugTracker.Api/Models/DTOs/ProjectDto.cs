namespace BugTracker.Api.Models.DTOs;

//<summary>
//Data Transfer Object for Project
//</summary>
public abstract class BaseProjectDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class ProjectDto : BaseProjectDto
{
    public int Id { get; set; }
}

public class UpdateProjectDto : BaseProjectDto
{
    public int Id { get; set; }
}

public class CreateProjectDto : BaseProjectDto
{
    public int UserId { get; set; }
}