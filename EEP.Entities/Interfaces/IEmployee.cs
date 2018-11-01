using System.Collections.Generic;


namespace EEP.Entities.Interfaces
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }

        User User { get; set; }

        ICollection<ProjectParticipationHistory> ParticipationHistoryInProject { get; set; }
    }
}
