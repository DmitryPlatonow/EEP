using EEP.DAL.Interfaces;
using EEP.Entities;
using System;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Web.Http;

namespace EEP.BL.Classes
{
    public class UserService : IUserService
                                    
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager _userManager;
        
        public UserService(IUnitOfWork unitOfWork, UserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public async Task<User> CreateAsync(User user)
        {
            var userSave = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateCreated = DateTime.Now,
                UserName= user.Email
            };
            var password = GetRandomPassword();
            var addUserResult = await _userManager.CreateAsync(userSave, password);

            foreach (var item in user.Roles)
            {
                var userAddToRoleresult = await _userManager.AddToRoleAsync(user.Id, item.ToString());
            }

            var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("YourAppName");
            _userManager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<User>(provider.Create("EmailConfirmation"));

            string code = await _userManager.GenerateEmailConfirmationTokenAsync(userSave.Id);
            var callbackUrl = userSave.Id + code;

            await _userManager.SendEmailAsync(userSave.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            return userSave;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return null;               
            }
            return user;           
        }

        public async Task<User> Ge(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return null;
            }
            return user;
        }


        private string GetRandomPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[12];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);

            return finalString;
        }


    }
}
