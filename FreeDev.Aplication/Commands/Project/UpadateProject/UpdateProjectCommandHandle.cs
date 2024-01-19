using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Commands.Project.UpadateProject;

public class UpdateProjectCommandHandle : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly FreeDevDbContext _context;
    public UpdateProjectCommandHandle(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.FindAsync(request.Id);
        project.Update(request.Title, request.Description, request.TotalCost);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
