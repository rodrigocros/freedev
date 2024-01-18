using FreeDev.API.Models;
using FreeDev.Aplication.Commands.User;
using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProjectService _projectService;
    private readonly IUserService _userService;

    public UsersController(IProjectService projectService, IUserService userService, IMediator mediator)
    {
        _mediator = mediator;
        _projectService = projectService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserByID(int id)
    {
        var user = _userService.GetByID(id);
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
