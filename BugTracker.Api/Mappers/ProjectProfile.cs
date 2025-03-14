using AutoMapper;
using BugTracker.Api.Models;
using BugTracker.Api.Models.DTO;

namespace BugTracker.Api.Mappers;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectDto, Project>().ReverseMap();
    }
}