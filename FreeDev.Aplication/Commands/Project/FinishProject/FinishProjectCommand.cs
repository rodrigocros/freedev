using MediatR;

namespace FreeDev.Aplication.Commands.Project.FinishProject;

public class FinishProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public FinishProjectCommand(int id)
    {
        Id = id;
    }
}

