using FreeDev.Core.Entities;
using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Commands.Project.CreateComment;

public class CreateCommentCommandHanddler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly FreeDevDbContext _context;
    public CreateCommentCommandHanddler(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
        await _context.ProjectComments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
