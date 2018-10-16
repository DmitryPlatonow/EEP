using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace EEP.DAL
{
    internal class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(role => new { role.RoleId, role.UserId });
          //  HasRequired(role => role.RoleId).WithMany().HasForeignKey(role => role.UserId);
        }
    }
}