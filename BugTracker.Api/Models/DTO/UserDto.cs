using BugTracker.Api.Models.Enum;

namespace BugTracker.Api.Models.DTO;

///<summary>
///Data Transfer Object for User
///</summary>
public class UserDto 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public ICollection<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
    public ICollection<BugDto> Bugs { get; set; } = new List<BugDto>();

}