using MediatR;

namespace FreeDev.Aplication.Commands.Project.UpadateProject;

public class UpdateProjectCommand : IRequest<Unit>
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal TotalCost { get; private set; }
}
