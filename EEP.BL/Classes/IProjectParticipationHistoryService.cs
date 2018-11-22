using EEP.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface IProjectParticipationHistoryService
    {
        Task<ProjectParticipationHistory> CreateAsync(ProjectParticipationHistory projectParticipationHistory);
        Task<IEnumerable<ProjectParticipationHistory>> GetAllAsync();
        Task<ProjectParticipationHistory> GetByIdAsync(int id);
        Task<ProjectParticipationHistory> UpdateAsync(ProjectParticipationHistory projectParticipationHistory);
        Task DeleteAsync(int id);
    }
}
