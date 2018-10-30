using EEP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsunc(Project project);

        Task<IEnumerable<Project>> GetAllAsync();

        Task<Project> GetProjectByIdAsunc(int? id);

        Task<Project> UpdateProjectAsync(Project project);

        Task DeleteProjectAsync(Project project);
    }
}
