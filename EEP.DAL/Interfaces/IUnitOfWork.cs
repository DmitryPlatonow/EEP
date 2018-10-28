using EEP.DAL.Repository;
using EEP.Entities;
using System;
using System.Threading.Tasks;

namespace EEP.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<User> UserRepository { get; }
         GenericRepository<Role> RoleRepository { get; }
        GenericRepository<Employee> EmployeeRepository { get; }
        GenericRepository<Project> ProjectRepository { get; }
        GenericRepository<ParticipationHistoryInProject> HistoryParticipationRepository { get; }
        void Commit();
        Task CommitAsync();
    }
}
