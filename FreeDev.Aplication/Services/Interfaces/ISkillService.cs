using FreeDev.Aplication.ViewModels;

namespace FreeDev.Aplication.Services.Interfaces;

public interface ISkillService
{
    List<SkillViewModel> GetAll();
}
