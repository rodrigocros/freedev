using MediatR;

namespace FreeDev.Aplication.Commands.User;

public class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}
