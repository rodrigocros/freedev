using FreeDev.API.Models;
using FreeDev.Aplication.Commands.User;
using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.Queries.User.GetAllUsers;
using FreeDev.Aplication.Queries.User.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
     
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByID(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody]CreateUserCommand newUser)
    {
        var id = await _mediator.Send(newUser);
        return CreatedAtAction(nameof(GetUserByID), new { id = id }, newUser);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
    {
        return Ok("Login");
    }
}
