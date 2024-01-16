using FreeDev.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProjects(string query)
    {
        return Ok("GetProjects");
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectByID(int id)
    {
        return Ok("GetProject");
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] CreateProjectModel project)
    {
        if(project == null || project.Title.Length > 50) 
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetProjectByID), new { id = project.id }, project);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, [FromBody] updateProjectModel updateProject)
    {
        if(updateProject == null || updateProject.Description.Length > 50) 
        {
            return BadRequest();
        }
        return Ok("UpdateProject");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        return Ok("DeleteProject");
    }

    [HttpPost("{id}/comments")]
    public IActionResult CreateComment(int id, [FromBody] CreateCommentModel comment)
    {
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult StartProject(int id)
    {
        return NoContent();
    }

    //finish
    [HttpPut("{id}/finish")]
    public IActionResult FinishProject(int id)
    {
        return NoContent();
    }


}
