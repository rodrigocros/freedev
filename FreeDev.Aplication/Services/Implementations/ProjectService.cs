using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.Services.Interfaces;
using FreeDev.Aplication.ViewModels;
using FreeDev.Core.Entities;
using FreeDev.Infrastructure.Percistence;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Aplication.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly FreeDevDbContext _context;
    public ProjectService(FreeDevDbContext context)
    {
        _context = context; 
    }
    public int Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Tittle, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
        _context.Projects.Add(project);
        _context.SaveChanges();

        return project.Id;
    }

    public void CreateComment(NewProjectCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
        _context.ProjectComments.Add(comment);
        _context.SaveChanges();

    }

    public void Delete(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == id);
        project.Cancel();
        _context.SaveChanges();

        
    }

    public void Finish(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == id);
        project.Finish();
        _context.SaveChanges();

    }

    public List<ProjectViewModel> GetAll()
    {
        var projects = _context.Projects.ToList();
        var projectViewModel = projects.Select(p => new ProjectViewModel(p.Id,p.Title, p.CreatedAt));
        return projectViewModel.ToList();
    }

    public ProjectDetailsViewModel GetByID(int id)
    {
        var project = _context.Projects.Include(p => p.Client).Include(p => p.Freelancer).FirstOrDefault(p => p.Id == id);
        var projectDetailsViewModel = new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt, project.Client.Name, project.Freelancer.Name);
        return projectDetailsViewModel;
    }

    public void Start(int id)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == id);
        project.Start();
        _context.SaveChanges();

    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == inputModel.Id);
        project.Update(inputModel.Tittle, inputModel.Description, inputModel.TotalCost);
        _context.SaveChanges();
        
    }
}
