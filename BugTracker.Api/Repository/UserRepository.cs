using BugTracker.Api.Contracts.Data;
using BugTracker.Api.Database;
using Microsoft.EntityFrameworkCore;
using BugTracker.Api.Models.DomainModels;
namespace BugTracker.Api.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public readonly BugTrackerDbContext _context;
    public UserRepository (BugTrackerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
        {
            // use logger to log the error
            return null;
        }

        return await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(u => EF.Functions.Like(u.Email, email));
    }

    public async Task<User?> GetDetails(int id)
    {
        // return the user with the assigned and reported bugs
        return await _context.Users
        .Include(u => u.AssignedBugs)
        .Include(u => u.ReportedBugs)
        .AsNoTracking()
        .FirstOrDefaultAsync(u => u.Id == id);
    }

    // possible method to get the user with the projects they are assigned to
    public async Task<IEnumerable<Project>> GetProjects(int userId)
    {
        return await _context.ProjectUsers
        .Include(pu => pu.Project)
        .Where(pu => pu.UserId == userId)
        .Select(pu => pu.Project)
        .ToListAsync();
    }
}

