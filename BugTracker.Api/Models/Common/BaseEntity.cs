namespace BugTracker.Api.Models.Common;

//<summary>
//Base Entity containing fields for all entities
//</summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
}