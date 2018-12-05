using EEP.Entities;
using System;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User user, string role);



       //   Task<ClaimsIdentity> Authenticate(User userDto);
       //   Task<OperationResult> ConfirmEmail(string userId, string code);

        //   Task<OperationResult> ResetPassword(string email, string code, string password);

        //Task<OperationResult> SendCodeToRetrievePassword(string email);
        //Task SignIn(User user, bool isPersistent, bool rememberMe);
        //Task<SignInStatus> SignIn(string userName, string password, bool rememberMe, bool shouldLockout);


    }
}
