using EEP.DAL.Interfaces;
using EEP.DAL.Repository;
using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private EEPDbContext _context = new EEPDbContext();

        private GenericRepository<User,Guid> _userRepository;
        private GenericRepository<Role,Guid> _roleRepository;

        private GenericRepository<Employee, int> _employeeRepository;
        private GenericRepository<Project, int> _projectRepository;
        private GenericRepository<ParticipationHistoryInProject, Guid> _participationHistoryInProjectRepository;


        public GenericRepository<User,Guid> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User, Guid>(_context);
                }
                return _userRepository;
            }
        }

        public GenericRepository<Role, Guid> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new GenericRepository<Role, Guid>(_context);
                }
                return _roleRepository;
            }
        }

        public GenericRepository<Employee, int> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new GenericRepository<Employee, int>(_context);
                }
                return _employeeRepository;
            }
        }

        public GenericRepository<Project, int> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new GenericRepository<Project, int>(_context);
                }
                return _projectRepository;
            }
        }

        public GenericRepository<ParticipationHistoryInProject, Guid> HistoryParticipationRepository
        {
            get
            {
                if (_participationHistoryInProjectRepository == null)
                {
                    _participationHistoryInProjectRepository = new GenericRepository<ParticipationHistoryInProject, Guid>(_context);
                }
                return _participationHistoryInProjectRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
