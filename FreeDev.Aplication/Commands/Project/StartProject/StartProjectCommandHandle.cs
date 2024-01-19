using FreeDev.Infrastructure.Percistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Aplication.Commands.Project.StartProject;

public class StartProjectCommandHandle : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly FreeDevDbContext _context;
    public StartProjectCommandHandle(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);
        project.Start();
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
