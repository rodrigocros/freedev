using FreeDev.Aplication.ViewModels;
using MediatR;

namespace FreeDev.Aplication.Queries.Project.GetProjectByID;

public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
