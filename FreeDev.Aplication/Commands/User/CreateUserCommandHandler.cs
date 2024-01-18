using FreeDev.Core.Entities;
using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Commands.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly FreeDevDbContext _context;
    public CreateUserCommandHandler(FreeDevDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Core.Entities.User(request.Name, request.Email, request.BirthDate);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }
}

