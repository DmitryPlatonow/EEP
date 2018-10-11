using EEP.DAL.Repository;
using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using EEP.BL.WorkClasses;
using System.Security.Principal;
using EEP.DAL.Repository.Extensions;

namespace EEP.BL.Classes
{
    public class UserService
    {

        private readonly GenericRepository<User> _userRepository;
        private readonly GenericRepository<Role> _roleRepository;
        private readonly GenericRepository<Employee> _employeeRepository;
        private readonly EncryptionService _encryptionService;
        private readonly UnitOfWork _unitOfWork;

        public UserService(GenericRepository<User> userRepository, GenericRepository<Role> roleRepository,
        GenericRepository<Employee> employeeRepository, EncryptionService encryptionService, UnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        public UserContext ValidateUser(string email, string password)
        {
            var userContext = new UserContext();

            var user = _userRepository.GetSingleByEmail(email);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Id);
                userContext.User = user;

                var identity = new GenericIdentity(user.Email);
                userContext.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }

            return userContext;
        }

        public User CreateUser(string username, string email, string lastName, string phoneNamber, string password, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByEmail(email);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new User()
            {
                FirstName = username,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNamber,
                Salt = passwordSalt,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                IsLocked = false,
                DateCreated = DateTime.Now   
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(user, role);
                }
            }

            _unitOfWork.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetByID(userId);
        }

        public List<Role> GetUserRoles(int id)
        {
            var result = new List<Role>();
            var existingUser = _userRepository.GetByID(id);

            if (existingUser != null)
            {
                result.Add(existingUser.Role);
            }
            return result;

        }

        private void addUserToRole(User user, int roleId)
        {
            var role = _roleRepository.GetByID(roleId);

            user.Role = role;
        }

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }
    }
}
