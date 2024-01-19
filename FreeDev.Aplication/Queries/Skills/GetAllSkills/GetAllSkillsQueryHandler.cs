using FreeDev.Aplication.ViewModels;
using FreeDev.Infrastructure.Percistence;
using MediatR;

namespace FreeDev.Aplication.Queries.Skills.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
{
    private readonly  FreeDevDbContext _context;
    public GetAllSkillsQueryHandler(FreeDevDbContext context)
    {
        _context = context;
    }
    public Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var dbSkills = _context.Skills.ToList();
        var skillsViewModel = dbSkills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
        return Task.FromResult(skillsViewModel);
    }
}
