namespace FreeDev.Core.Entities;

public class ProjectComment : BaseEntity
{
    public ProjectComment(string text, int idProject, int idUser)
    {
        Content = text;
        IdProject = idProject;
        IdUser = idUser;
        CreatedAt = DateTime.Now;
    }

    public string Content { get; private set; }
    public int IdProject { get; private set; }
    public int IdUser { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
