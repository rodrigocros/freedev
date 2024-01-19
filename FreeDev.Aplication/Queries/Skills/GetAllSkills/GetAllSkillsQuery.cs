using FreeDev.Aplication.ViewModels;
using MediatR;

namespace FreeDev.Aplication.Queries.Skills.GetAllSkills;

public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
{
    public int Id { get; private set; }
    public string Description { get; private set; }

}
