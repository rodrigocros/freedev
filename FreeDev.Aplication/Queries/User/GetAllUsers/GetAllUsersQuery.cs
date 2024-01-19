using FreeDev.Aplication.ViewModels;
using MediatR;

namespace FreeDev.Aplication.Queries.User.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserViewModel>>
{

}
