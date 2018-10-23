using EEP.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(DbContext context) : base(context)
        {
        }
    }
}
