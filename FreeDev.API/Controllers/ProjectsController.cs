using FreeDev.API.Models;
using FreeDev.Aplication.Commands.CreateProject;
using FreeDev.Aplication.Commands.Project.CreateComment;
using FreeDev.Aplication.Commands.Project.DeleteProject;
using FreeDev.Aplication.Commands.Project.FinishProject;
using FreeDev.Aplication.Commands.Project.StartProject;
using FreeDev.Aplication.Commands.Project.UpadateProject;
using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.Queries.Project.GetAllProject;
using FreeDev.Aplication.Queries.Project.GetProjectByID;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{

    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //Projects?query=Rodrigo
    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var GetAllProject = new GetAllProjectsQuery();
        var projects = await _mediator.Send(GetAllProject);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async  Task<IActionResult> GetProjectByID(int id)
    {
        var project = new GetProjectByIdQuery(id);
        var projectDetails = await _mediator.Send(project);
        return Ok(projectDetails);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand project)
    {
        if(project == null || project.Description.Length > 50) 
        {
            return BadRequest();
        }
        var id = await _mediator.Send(project);
        return CreatedAtAction(nameof(GetProjectByID), new { id = id }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectCommand inputModel)
    {
        if(inputModel == null || inputModel.Description.Length > 50) 
        {
            return BadRequest();
        }
        await _mediator.Send(inputModel);
        return NoContent();
     }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var command = new DeleteProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult CreateComment(int id, [FromBody] CreateCommentCommand comment)
    {
        if(comment == null || comment.Content.Length > 50) 
        {
            return BadRequest();
        }
        comment.IdProject = id;
        _mediator.Send(comment);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> StartProject(int id)
    {
        await _mediator.Send(new StartProjectCommand(id));
        return NoContent();
    }

    //finish
    [HttpPut("{id}/finish")]
    public async Task<IActionResult> FinishProject(int id)
    {
        await _mediator.Send(new FinishProjectCommand(id));
        return NoContent();
    }


}
