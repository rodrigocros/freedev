using System.CodeDom.Compiler;
using FreeDev.Aplication.Queries.Skills.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSkills()
    {
        var query = new GetAllSkillsQuery();
        var skills = await _mediator.Send(query);
        return Ok(skills);   
    }

}
