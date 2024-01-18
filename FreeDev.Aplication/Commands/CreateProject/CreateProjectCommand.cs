using MediatR;

namespace FreeDev.Aplication.Commands.CreateProject;

public class CreateProjectCommand : IRequest<int> // retorna int
{
    public string Tittle { get; set; }
    public string Description { get; set; }
    public int IdClient { get; set; }
    public int IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
}

