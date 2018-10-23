using System;
using System.Data.Entity;
using EEP.DAL;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EEP.BL.Classes
{
    public class UserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(DbContext context)
            : base(context) { }
    }
}