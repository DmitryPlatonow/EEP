using EEP.Entities.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EEP.Entities
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public EmployeeRoleInProject EmployeeRoleInProject { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public Role Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;

        }

        public static implicit operator IdentityUser(User v)
        {
            throw new NotImplementedException();
        }
    }
}
