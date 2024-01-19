using FreeDev.Aplication.ViewModels;
using MediatR;

namespace FreeDev.Aplication.Queries.Project.GetAllProject;

public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
{

}
