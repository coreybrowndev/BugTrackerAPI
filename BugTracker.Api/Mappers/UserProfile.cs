using AutoMapper;
using BugTracker.Api.Models;
using BugTracker.Api.Models.DTO;

namespace BugTracker.Api.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>().ReverseMap();
    }
}