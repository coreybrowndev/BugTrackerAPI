using AutoMapper;
using BugTracker.Api.Models.DomainModels;
using BugTracker.Api.Models.DTOs;

namespace BugTracker.Api.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}