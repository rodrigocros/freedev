using FreeDev.Infrastructure.Percistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Aplication.Commands.Project.FinishProject;

public class FinishProjectCommandHandle : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly FreeDevDbContext _context;
    public FinishProjectCommandHandle(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);
        project.Finish();
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}

