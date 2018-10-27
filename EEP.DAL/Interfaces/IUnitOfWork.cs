using EEP.DAL.Repository;
using EEP.Entities;
using System;
using System.Threading.Tasks;

namespace EEP.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<User, Guid> UserRepository { get; }


         GenericRepository<Role, Guid> RoleRepository { get; }

        GenericRepository<Employee, int> EmployeeRepository { get; }

        GenericRepository<Project, int> ProjectRepository { get; }
        GenericRepository<ParticipationHistoryInProject, Guid> HistoryParticipationRepository { get; }
        void Commit();
        Task CommitAsync();
    }
}
