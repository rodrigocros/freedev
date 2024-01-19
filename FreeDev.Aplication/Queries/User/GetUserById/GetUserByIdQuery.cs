using FreeDev.Aplication.ViewModels;
using MediatR;

namespace FreeDev.Aplication.Queries.User.GetUserById;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
