using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface IProjectService
    {
        Task<Project> CreateAsync(Project project);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<Project> UpdateAsync(Project project);

        Task DeleteAsync(int id);

    }
}
