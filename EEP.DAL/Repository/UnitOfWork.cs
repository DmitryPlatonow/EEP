using EEP.Entities;
using System;


namespace EEP.DAL.Repository
{

    public class UnitOfWork

    {
        private EEPDbContext _context = new EEPDbContext();
        private GenericRepository<User> _userRepository;
        private GenericRepository<Role> _roleRepository;
        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<Project> _projectRepository;
        private GenericRepository<HistoryParticipation> _historyParticipationRepository;

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

        public GenericRepository<HistoryParticipation> HistoryParticipationRepository
        {
            get
            {
                if (_historyParticipationRepository == null)
                {
                    _historyParticipationRepository = new GenericRepository<HistoryParticipation>(_context);
                }
                return _historyParticipationRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
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