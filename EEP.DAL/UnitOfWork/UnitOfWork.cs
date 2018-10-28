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

        private GenericRepository<User> _userRepository;
        private GenericRepository<Role> _roleRepository;

        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<Project> _projectRepository;
        private GenericRepository<ParticipationHistoryInProject> _participationHistoryInProjectRepository;


        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new GenericRepository<Role>(_context);
                }
                return _roleRepository;
            }
        }

        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new GenericRepository<Employee>(_context);
                }
                return _employeeRepository;
            }
        }

        public GenericRepository<Project> ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new GenericRepository<Project>(_context);
                }
                return _projectRepository;
            }
        }

        public GenericRepository<ParticipationHistoryInProject> HistoryParticipationRepository
        {
            get
            {
                if (_participationHistoryInProjectRepository == null)
                {
                    _participationHistoryInProjectRepository = new GenericRepository<ParticipationHistoryInProject>(_context);
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
