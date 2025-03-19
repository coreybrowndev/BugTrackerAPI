using BugTracker.Api.Models.DomainModels;
namespace BugTracker.Api.Contracts.Data;
public interface IProjectRepository : IGenericRepository<Project>
{
    Task<Project> GetProjectByIdAsync(int id);
    Task<Project> GetAllProjectsAsync();
    Task<Project> AddProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(Project project);
    Task<Project> DeleteProjectAsync(Project project);
    Task<Project> SaveProjectAsync();
}