using EEP.DAL;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class UserManager : UserManager<User, Guid> //, IApplicationUserManager
    {

        public UserManager(IUserStore<User, Guid> store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore(context.Get<EEPDbContext>()));

            manager.UserValidator = new UserValidator<User, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = true
            };

            //Validation password
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            //провайдеры для реализации двуфакторной авторизации
            //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, Guid>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, Guid>
            //{
            //    Subject = "Security Code",
            //    BodyFormat = "Your security code is {0}"
            //});

            //manager.EmailService = new ApplicationEmailService();
            //manager.SmsService = new ApplicationSmsService();

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;

        }

        public IEnumerable<User> GetUsers()
        {
            return Users.ToList();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user)
        {            
            var userIdentity = await CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);          
            return userIdentity;
        }
    }
}
