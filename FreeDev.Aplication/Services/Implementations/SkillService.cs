using FreeDev.Aplication.Services.Interfaces;
using FreeDev.Aplication.ViewModels;
using FreeDev.Infrastructure.Percistence;

namespace FreeDev.Aplication.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly FreeDevDbContext _context;
    public SkillService(FreeDevDbContext context)
    {
        _context = context;
    }
    public List<SkillViewModel> GetAll()
    {
        var dbSkills = _context.Skills.ToList();
        var skillsViewModel = dbSkills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
        return skillsViewModel;
    }
}
