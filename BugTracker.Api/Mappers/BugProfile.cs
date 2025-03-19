using AutoMapper;
using BugTracker.Api.Models.DomainModels;
using BugTracker.Api.Models.DTOs;

namespace BugTracker.Api.Mappers;

public class BugProfile : Profile
{
    public BugProfile()
    {
        CreateMap<Bug, BugDto>().ReverseMap();
    }
}