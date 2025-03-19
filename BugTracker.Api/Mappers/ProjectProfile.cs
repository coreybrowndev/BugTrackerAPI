using AutoMapper;
using BugTracker.Api.Models.DomainModels;
using BugTracker.Api.Models.DTOs;

namespace BugTracker.Api.Mappers;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>().ReverseMap();
    }
}