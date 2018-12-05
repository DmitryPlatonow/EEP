using EEP.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EEP.DAL.Repository
{
    public class UserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(EEPDbContext context)
              : base(context)
        {
        }
    }
}
