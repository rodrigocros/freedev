using MediatR;

namespace FreeDev.Aplication.Commands.Project.StartProject;

public class StartProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
    public StartProjectCommand(int id)
    {
        Id = id;
    }
}

