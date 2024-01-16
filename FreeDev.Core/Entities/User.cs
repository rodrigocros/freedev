using System.Reflection.Metadata;

namespace FreeDev.Core.Entities;

public class User : BaseEntity
{
    public User(string name, string email, DateTime birthDate)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Active = true;

        CreatedAt = DateTime.Now;
        Skills = new List<UserSkill>();
        Projects = new List<Project>();
        ProjectsAsFreelancer = new List<Project>();
        ProjectsAsClient = new List<Project>();

    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<UserSkill > Skills{ get; private set; }
    public bool Active { get; set; }
    public List<Project> Projects { get; private set; }
    public List<Project> ProjectsAsFreelancer { get; private set; }
    public List<Project> ProjectsAsClient { get; private set; }



    
}
