namespace FreeDev.Aplication.ViewModels;

public class UserViewModel
{
    public UserViewModel(int id, string name, string email, DateTime birthDate)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate {  get; private set; }
}
