using EEP.DAL;
using EEP.DAL.Repository;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class UserManager : UserManager<User, Guid>
    {
        public UserManager(IUserStore<User, Guid> store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {

            var manager = new UserManager(new UserStore(context.Get<EEPDbContext>()));

            manager.EmailService = new EmailService();
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, Guid>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    
                    TokenLifespan = TimeSpan.FromHours(6)

                };
               
            }
            return manager;
        }


    }
}