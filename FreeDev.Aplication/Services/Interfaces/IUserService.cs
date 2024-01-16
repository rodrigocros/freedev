using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.ViewModels;

namespace FreeDev.Aplication.Services.Interfaces;

public interface IUserService
{
    int Create(NewUserInputModel inputModel);
    void Delete(int id);
    List<UserViewModel> GetAll(string query);
    UserViewModel GetByID(int id);
    void Update(int id, UpdateUserInputModel inputModel);
}
