namespace EEP.DAL.Migrations
{
    using EEP.Entities;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<EEP.DAL.EEPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(EEP.DAL.EEPDbContext context)
        {

            {
                var userManager = new UserManager<User, Guid>(new EEP.DAL.Repository.UserStore(context));
                userManager.UserValidator = new UserValidator<User, Guid>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                var roleManager = new RoleManager<Role, Guid>(new EEP.DAL.Repository.RoleStore(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new Role() { Id = new Guid() , Name = "Admin" });
                }


                //if (!roleManager.RoleExists("Resurse Manager"))
                //{
                //    roleManager.Create(new Role() { Id = new Guid(),  Name = "Resurse Manager" });
                //}

                //if (!roleManager.RoleExists("Project Manager"))
                //{
                //    roleManager.Create(new Role() { Id = new Guid(), Name = "Project Manager" });
                //}

                //if (!roleManager.RoleExists("Employee"))
                //{
                //    roleManager.Create(new Role() { Id = new Guid(),  Name = "Employee" });
                //}

                User user = new User();
                user.FirstName = "Admin";
                user.LastName = "admin";
                user.Email = "admin@admin.com";
                user.UserName = "admin@admin.com";
                user.DateCreated = DateTime.Now;

                IdentityResult userResult = userManager.Create(user, "Password*shop1");

                if (userResult.Succeeded)
                {
                    var user1 = userManager.FindByName("admin@admin.com");
                    userManager.AddToRole(user1.Id, "Admin");
                }
            }
        }
    }
}
