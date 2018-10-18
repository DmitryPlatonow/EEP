namespace EEP.DAL.Migrations
{
    using EEP.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EEP.DAL.EEPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(EEP.DAL.EEPDbContext context)
        {

            {

                var userManager = new UserManager<User>(new UserStore<User>(context));
                userManager.UserValidator = new UserValidator<User>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Employee"))
                {
                    roleManager.Create(new IdentityRole("Employee"));
                }
                if (!roleManager.RoleExists("Project Manager"))
                {
                    roleManager.Create(new IdentityRole("Project Manager"));
                }
                if (!roleManager.RoleExists("Resurse Manager"))
                {
                    roleManager.Create(new IdentityRole("Resurse Manager"));
                }

                var user = new User();
                user.FirstName = "Admin";
                user.LastName = "admin";
                user.Email = "admin@admin.com";
                user.UserName = "admin@admin.com";
                user.DateCreated = DateTime.Now;

                var userResult = userManager.Create(user, "password*shop1");

                if (userResult.Succeeded)
                {
                    var user1 = userManager.FindByName("admin@admin.com");
                    userManager.AddToRole(user1.Id, "Admin");
                }


            }
        }
    }
}
