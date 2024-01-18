using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.Services.Interfaces;
using FreeDev.Aplication.ViewModels;
using FreeDev.Core.Entities;
using FreeDev.Infrastructure.Percistence;

namespace FreeDev.Aplication.Services.Implementations;

public class UserService : IUserService
{
     private readonly FreeDevDbContext _context;
    public UserService(FreeDevDbContext context)
    {
        _context = context; 
    }
    public int Create(NewUserInputModel inputModel)
    {
        var user = new User(inputModel.Name, inputModel.Email, inputModel.BirthDate);
        _context.Users.Add(user);
        _context.SaveChanges();

        return user.Id;
    }

    public void Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        _context.Users.Remove(user);
        _context.SaveChanges();

    }

    public List<UserViewModel> GetAllUsers()
    {
        var users = _context.Users.ToList();
        return users.Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.BirthDate)).ToList();
    }

    public UserViewModel GetByID(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        var userViewModel = new UserViewModel(user.Id, user.Name, user.Email, user.BirthDate);
        return userViewModel;
    }

    public void Update(int id, UpdateUserInputModel inputModel)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        _context.Users.Remove(user);
        _context.SaveChanges();
        
    }
}
