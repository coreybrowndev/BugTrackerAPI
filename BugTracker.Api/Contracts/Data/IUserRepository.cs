using BugTracker.Api.Models.DomainModels;
namespace BugTracker.Api.Contracts.Data;
public interface IUserRepository : IGenericRepository<User>
{   
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetDetails(int id);
}