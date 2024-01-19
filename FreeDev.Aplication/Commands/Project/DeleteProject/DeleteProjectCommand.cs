using MediatR;

namespace FreeDev.Aplication.Commands.Project.DeleteProject;

public class DeleteProjectCommand : IRequest<Unit>
{
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
