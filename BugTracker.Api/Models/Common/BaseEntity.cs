namespace BugTracker.Api.Models.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
}