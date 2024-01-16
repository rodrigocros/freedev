using FreeDev.API.Models;
using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IUserService _userService;

    public ProjectsController(IProjectService projectService, IUserService userService)
    {
        _projectService = projectService;
        _userService = userService;
    }

    //Projects?query=Rodrigo
    [HttpGet]
    public IActionResult GetProjects()
    {
        var projects = _projectService.GetAll();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectByID(int id)
    {
        var project = _projectService.GetByID(id);
        if(project == null) 
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] NewProjectInputModel project)
    {
        if(project == null || project.Description.Length > 50) 
        {
            return BadRequest();
        }
        var id = _projectService.Create(project);
        return CreatedAtAction(nameof(GetProjectByID), new { id = id }, project);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, [FromBody] UpdateProjectInputModel inputModel)
    {
        if(inputModel == null || inputModel.Description.Length > 50) 
        {
            return BadRequest();
        }
        _projectService.Update(inputModel);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        _projectService.Delete(id);
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult CreateComment(int id, [FromBody] NewProjectCommentInputModel comment)
    {
        if(comment == null || comment.Content.Length > 50) 
        {
            return BadRequest();
        }
        _projectService.CreateComment(comment);
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult StartProject(int id)
    {
        _projectService.Start(id);
        return NoContent();
    }

    //finish
    [HttpPut("{id}/finish")]
    public IActionResult FinishProject(int id)
    {
        _projectService.Finish(id);
        return NoContent();
    }


}
