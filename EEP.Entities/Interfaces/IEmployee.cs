using System.Collections.Generic;


namespace EEP.Entities.Interfaces
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }

        User User { get; set; }

        ICollection<ParticipationHistoryInProject> ParticipationHistoryInProject { get; set; }
    }
}
