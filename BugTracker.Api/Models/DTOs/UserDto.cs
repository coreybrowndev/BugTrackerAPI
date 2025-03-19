using System.ComponentModel.DataAnnotations;
using BugTracker.Api.Models.Enum;
namespace BugTracker.Api.Models.DTOs;

///<summary>
///Data Transfer Object for User
///</summary>
///

public abstract class BaseUserDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}

public class UserDto : BaseUserDto
{
    public int Id { get; set; }
}

public class UpdateUserDto : BaseUserDto
{
    public int Id { get; set; }
}

public class CreateUserDto : BaseUserDto
{
    
}

public class UserDetailsDto : BaseUserDto
{
    public int Id { get; set; }
    public ICollection<BugDto> AssignedBugs { get; set; } = new List<BugDto>();
    public ICollection<BugDto> ReportedBugs { get; set; } = new List<BugDto>();
}
