using FreeDev.Core.Entities;
using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly FreeDevDbContext _context;
    public CreateProjectCommandHandler(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Tittle, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();

        return project.Id;
    }
}
