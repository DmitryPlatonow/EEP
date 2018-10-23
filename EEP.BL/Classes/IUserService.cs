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
    public interface IUserService
    {


        Task<OperationResult> Create(UserDto userDto);



          Task<ClaimsIdentity> Authenticate(UserDto userDto);
          Task<OperationResult> ConfirmEmail(Guid userId, string code);

          Task<OperationResult> ResetPassword(string email, string code, string password);

       Task<OperationResult> SendCodeToRetrievePassword(string email);
       //Task SignIn(User user, bool isPersistent, bool rememberMe);
       //Task<SignInStatus> SignIn(string userName, string password, bool rememberMe, bool shouldLockout);


    }
}
