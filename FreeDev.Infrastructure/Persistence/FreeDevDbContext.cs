using FreeDev.Core.Entities;

namespace FreeDev.Infrastructure.Percistence;

public class FreeDevDbContext
{
    public FreeDevDbContext()
    {
        Projects = new List<Project>()
        {
            new Project("Project 1", "Description 1", 1, 2, 1000),
            new Project("Project 2", "Description 2", 2, 3, 2000),
            new Project("Project 3", "Description 3", 3, 4, 3000),
        };
        Users = new List<User>()
        {
            new User("Rafael", "teste@teste.com.br", new DateTime(1990, 1, 1)),
            new User("Rodrigo", "Rodrigo@teste.com.br", new DateTime(1990, 1, 1)),
            new User("Jorge", "Rodrigo@teste.com.br", new DateTime(1990, 1, 1)),

        };
        Skills = new List<Skill>()
        {
            new Skill("C#"),
            new Skill("Java"),
            new Skill("Python"),
            new Skill("JavaScript"),
            new Skill("PHP")
        };
    }
    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }
    public List<ProjectComment> ProjectComments { get; set; }

}
