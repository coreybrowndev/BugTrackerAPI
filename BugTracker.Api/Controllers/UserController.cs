using BugTracker.Api.Models.DTOs;
using AutoMapper;
using BugTracker.Api.Contracts.Data;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Api.Exceptions;
using BugTracker.Api.Models.DomainModels;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BugTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        // get all users
        var users = await _userRepository.GetAllAsync();
        var records = _mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(records);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        // get user by id
        var user = await _userRepository.GetByIdAsync(id) ?? throw new NotFoundException("User", id);

        // map user
        var userDto = _mapper.Map<UserDto>(user);

        // return response
        return Ok(userDto);
    }

    [HttpGet("/email/{email}")]
    public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
    {
        // get user by email
        var user = await _userRepository.GetUserByEmailAsync(email) ?? throw new NotFoundException("User", email);

        // map user
        var userDto = _mapper.Map<UserDto>(user);

        // return response
        return Ok(userDto);
    }

    [HttpGet("/details/{id}")]
    public async Task<ActionResult<UserDetailsDto>> GetUserDetails(int id)
    {
        // get user by id
        var user = await _userRepository.GetDetails(id) ?? throw new NotFoundException("User", id);

        // map user
        var userDto = _mapper.Map<UserDetailsDto>(user);

        // return response
        return Ok(userDto);
    }

    [HttpGet("/projects/{id}")]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetUserProjects(int id)
    {
        // get projects by user id
        var projects = await _userRepository.GetProjects(id);

        // map projects
        var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);

        // return response
        return Ok(projectDtos);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto newUser)
    {
        // map the user
        var user = _mapper.Map<User>(newUser);

        // save the user
        var newEntity = await _userRepository.AddAsync(user);

        //map to created
        var userDto = _mapper.Map<UserDto>(newEntity);

        return CreatedAtAction(nameof(GetUser), new { id = newEntity.Id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateUserDto>> PutUser(int id, UpdateUserDto updatedUser)
    {
        // validate id
        if(id != updatedUser.Id)
        {
            throw new BadRequestException("Invalid record id");
        }

        // map the user
        var entity = _mapper.Map<User>(updatedUser);

        // save the user
        try {
            await _userRepository.UpdateAsync(entity);

            return NoContent();
        } catch (DBConcurrencyException ex)
        {
            if(!await UserExists(id))
            {
                throw new NotFoundException("User", id);
            }
            
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if(!await _userRepository.DeleteAsync(id))
        {
            throw new NotFoundException("User", id);
        }

        return NoContent();
    }

    private Task<bool> UserExists(int id)
    {
        return _userRepository.ExistsAsync(id);
    }
}