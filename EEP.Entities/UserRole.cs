﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EEP.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual Role Role { get; set; }
    }
}