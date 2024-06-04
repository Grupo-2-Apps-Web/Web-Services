using ACME.CargoApp.API.User.Domain.Model.Queries;
using ACME.CargoApp.API.User.Domain.Services;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;
using ACME.CargoApp.API.User.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.CargoApp.API.User.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IUserQueryService userQueryService, IUserCommandService userCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserResource createUserResource)
    {
        try
        {
            var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(createUserResource);
            var user = await userCommandService.Handle(createUserCommand);
            if (user is null) return BadRequest();
            var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the user. " + e.Message });
        }
    }
    
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserResource updateUserResource, [FromRoute] int userId)
    {
        try
        {
            var updateUserCommand = UpdateUserCommandFromResourceAssembler.ToCommandFromResource(updateUserResource, userId);
            var user = await userCommandService.Handle(updateUserCommand);
            if (user is null) return BadRequest();
            var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
            return Ok(resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while updating the user. " + e.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var resources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        var user = await userQueryService.Handle(new GetUserByIdQuery(userId));
        if (user == null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(resource);
    }
}