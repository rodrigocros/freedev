using FreeDev.Core.Enums;

namespace FreeDev.Aplication.ViewModels;

public class ProjectDetailsViewModel
{
    public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime startedAt, DateTime finishedAt, string clientName, string freelancerName, ProjectStatusEnum status)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        ClientName = clientName;
        FreelancerName = freelancerName;

    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal? TotalCost { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime FinishedAt { get; private set; }
    public string ClientName { get; private set; }
    public string FreelancerName { get; private set; }
    public ProjectStatusEnum Status { get; private set; }

}
