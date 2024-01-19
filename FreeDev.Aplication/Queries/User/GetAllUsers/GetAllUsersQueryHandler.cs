using FreeDev.Aplication.ViewModels;
using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Queries.User.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly  FreeDevDbContext _context;
    public GetAllUsersQueryHandler(FreeDevDbContext context)
    {
        _context = context;
    }
    public Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var dbUsers = _context.Users.ToList();
        var usersViewModel = dbUsers.Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.BirthDate)).ToList();
        return Task.FromResult(usersViewModel);
    }
}

