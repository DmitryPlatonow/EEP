using EEP.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.DAL.Repository
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(EEPDbContext context)
            : base(context)
        {
                
        }
    }
}
