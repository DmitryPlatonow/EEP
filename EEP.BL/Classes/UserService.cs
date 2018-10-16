using EEP.DAL.Repository;
using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using EEP.BL.WorkClasses;
using System.Security.Principal;
using EEP.DAL.Repository.Extensions;
using EEP.DAL.Repository.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using EEP.DAL;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class UserService : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly EncryptionService _encryptionService;

        //kostillll popravit
       // private readonly EEPDbContext _db;

        private UserManager<IdentityUser> _userManager;

        public UserService()
        {
            _unitOfWork = new UnitOfWork();
            _encryptionService = new EncryptionService();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
        }

        //public UserContext ValidateUser(string email, string password)
        //{
        //    var userContext = new UserContext();

        //    var user = _unitOfWork.UserRepository.GetSingleByEmail(email);
        //    if (user != null && IsUserValid(user, password))
        //    {
        //        var userRole = new string[] { GetUserRole(user.Id).ToString() };
        //        userContext.User = user;
        //        var identity = new GenericIdentity(user.Email);
        //        userContext.Principal = new GenericPrincipal(identity, userRole);
        //    }
        //    return userContext;
        //}

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IdentityResult> CreateUser(User userin)
        {

            IdentityUser user = new IdentityUser
            {
                UserName = userin.UserName
            };

            var result = await _userManager.CreateAsync(user);

            return result;
            //var existingUser = _unitOfWork.UserRepository.GetSingleByEmail(user.Email);

            //if (existingUser != null)
            //{
            //    throw new Exception("Username is already in use");
            //}

            //var passwordSalt = _encryptionService.CreateSalt();  

            //_unitOfWork.UserRepository.Add(user);
            //_unitOfWork.Commit();

            //return user;
        }

        public async Task<IdentityUser> GetUser(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId); // FindById(userId);
            return result; //.UserRepository.GetByID(int.Parse(userId));
        }

        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            var result = await _userManager.FindByEmailAsync(email); // FindById(userId);
            return result; //.UserRepository.GetByID(int.Parse(userId));
        }

        public async Task<IdentityUser> Login(string email, string password)
        {
            var userResult = _userManager.FindByEmail(email);


            var result = await _userManager.CheckPasswordAsync(userResult, password); // FindById(userId);
            return userResult; //.UserRepository.GetByID(int.Parse(userId));
        }
        //public Role GetUserRole(int id)
        //{
        //    var result = new Role();
        //    var existingUser = _unitOfWork.UserRepository.GetByID(id);
        //    result = existingUser.Role;
        //    return result;
        //}

        //private void AddUserToRole(User user, int roleId)
        //{
        //    var role = _unitOfWork.RoleRepository.GetByID(roleId);

        //    user.Role = role;
        //}

        //private bool IsPasswordValid(User user, string password)
        //{
        //    return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        //}

        //private bool IsUserValid(User user, string password)
        //{
        //    if (IsPasswordValid(user, password))
        //    {
        //        return !user.IsLocked;
        //    }
        //    return false;
        //}
    }
}
