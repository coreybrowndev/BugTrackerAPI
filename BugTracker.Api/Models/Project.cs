using BugTracker.Api.Models.Common;

namespace BugTracker.Api.Models;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}