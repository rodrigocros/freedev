using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Commands.Project.DeleteProject;

public class DeleteProjectCommandHanddler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly FreeDevDbContext _context;
    public DeleteProjectCommandHanddler(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.FindAsync(request.Id);
        project.Cancel();
        await _context.SaveChangesAsync();

        return Unit.Value;
    }

}
