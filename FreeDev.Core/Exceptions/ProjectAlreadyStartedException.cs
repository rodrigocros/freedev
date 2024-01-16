namespace FreeDev.Core.Exceptions;

public class ProjectAlreadyStartedException : Exception
{
    public ProjectAlreadyStartedException() : base("Project already started")
    {
    }
}
