using FreeDev.Aplication.ViewModels;
using FreeDev.Infrastructure.Percistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Aplication.Queries.Project.GetAllProject;

public class GetAllProjectsQueryHanddler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly FreeDevDbContext _context;

    public GetAllProjectsQueryHanddler(FreeDevDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = _context.Projects;
        var projectViewModels = await projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToListAsync();
        return projectViewModels;
    }

}
