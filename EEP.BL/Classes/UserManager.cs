using EEP.DAL;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace EEP.BL.Classes
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<EEPDbContext>();
            var appUserManager = new UserManager(new UserStore<User>(appDbContext));

            return appUserManager;
        }
    }
}