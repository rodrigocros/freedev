using FreeDev.Aplication.ViewModels;
using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Queries.User.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly FreeDevDbContext _context;
    public GetUserByIdQueryHandler(FreeDevDbContext context)
    {
        _context = context;
    }
    public Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var dbUser = _context.Users.FirstOrDefault(u => u.Id == request.Id);
        var userViewModel = new UserViewModel(dbUser.Id, dbUser.Name, dbUser.Email, dbUser.BirthDate);
        return Task.FromResult(userViewModel);
    }
}
