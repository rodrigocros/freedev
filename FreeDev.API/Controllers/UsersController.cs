using FreeDev.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUserByID(int id)
    {
        return Ok("GetUserByID");
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody]userForRegisterDto userForRegisterDto)
    {
        return CreatedAtAction(nameof(GetUserByID), new { id = userForRegisterDto.UserName }, userForRegisterDto);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
    {
        return Ok("Login");
    }
}
