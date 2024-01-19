using FreeDev.Aplication.ViewModels;
using FreeDev.Infrastructure.Percistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Aplication.Queries.Project.GetProjectByID;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
{
    private readonly FreeDevDbContext _context;
    public GetProjectByIdQueryHandler(FreeDevDbContext context)
    {
        _context = context;
    }

    public Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.Include(p => p.Client).Include(p => p.Freelancer).FirstOrDefault(p => p.Id == request.Id);
        var projectDetailsViewModel = new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt, project.Client.Name, project.Freelancer.Name, project.Status);
        return Task.FromResult(projectDetailsViewModel);       
    }
}
