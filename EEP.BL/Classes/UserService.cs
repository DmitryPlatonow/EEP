using EEP.DAL.Interfaces;
using AutoMapper;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EEP.Entities.Dto;

namespace EEP.BL.Classes
{
    public class UserService : IUserService
    {
        protected readonly UserManager _userManager;
     //   protected readonly SignInManager _signInManager;

        public UserService(UserManager userManager)//, SignInManager signInManager
        {
            _userManager = userManager;
            //_signInManager = signInManager;
        }


        public async Task<OperationResult> Create(UserDto userDto)
        {

            User user = await _userManager.FindByNameAsync(userDto.UserName);

            if (user == null)
            {
                user = Mapper.Map<User>(userDto);
                if (user.Id == Guid.Empty)
                    user.Id = Guid.NewGuid();

                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() > 0)
                    return new OperationResult(false, result.Errors.FirstOrDefault(), "");

                return new OperationResult(true, "Registration successfully complited", "");
            }
            else
            {
                return new OperationResult(false, "This user is already exists", "UserName");
            }
        }


        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            User user = await _userManager.FindAsync(userDto.UserName, userDto.Password);

            if (user != null)
                claim = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;
        }

        public async Task<OperationResult> ConfirmEmail(Guid userId, string code)
        {
            var result = await _userManager.ConfirmEmailAsync(userId, code);
            if (result.Errors.Count() > 0)
                return new OperationResult(false, result.Errors.FirstOrDefault(), "");

            return new OperationResult(true, "Email confirmed", "");
        }

        public async Task<OperationResult> ResetPassword(string email, string code, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return new OperationResult(false, "The user does not exist", "");
            }
            var result = await _userManager.ResetPasswordAsync(user.Id, code, password);
            if (result.Errors.Count() > 0)
            {
                return new OperationResult(false, result.Errors.FirstOrDefault(), "");
            }

            return new OperationResult(true, "Password was successfully updated", "");
        }

        public async Task<OperationResult> SendCodeToRetrievePassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
            {
                return new OperationResult(false, "User does not exists or is not confirmed", "");
            }

            return new OperationResult(true, "The code for password confirmation has been sent", "");
        }

        //public async Task SignIn(User user, bool isPersistent, bool rememberMe)
        //{
        //    await _signInManager.SignInAsync(user, isPersistent, rememberMe);
        //}

        //public async Task<SignInStatus> SignIn(string userName, string password, bool rememberMe, bool shouldLockout)
        //{
        //    return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout);
        //}


    }
}
