using FreeDev.Aplication.InputModels;
using FreeDev.Aplication.ViewModels;

namespace FreeDev.Aplication.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll();
    ProjectDetailsViewModel GetByID(int id);

    int Create(NewProjectInputModel inputModel);
    void Update(UpdateProjectInputModel inputModel);
    void CreateComment(NewProjectCommentInputModel inputModel);
    void Delete(int id);
    void Start(int id);
    void Finish(int id);
}
