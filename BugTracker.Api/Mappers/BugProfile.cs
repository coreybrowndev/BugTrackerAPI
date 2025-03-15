using AutoMapper;
using BugTracker.Api.Models;
using BugTracker.Api.Models.DTO;

namespace BugTracker.Api.Mappers;

public class BugProfile : Profile
{
    public BugProfile()
    {
        CreateMap<Bug, BugDto>().ReverseMap();
    }
}