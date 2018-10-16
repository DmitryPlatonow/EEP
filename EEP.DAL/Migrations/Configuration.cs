namespace EEP.DAL.Migrations
{
    using EEP.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EEP.DAL.EEPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(EEP.DAL.EEPDbContext context)
        {
            //if (!context.Roles.Any(r => r.Name == "Admin"))
            //{

            //    //var roleAdmin = new Role() { Name = "Admin" };
            //    //var roleResursManager = new Role() { Name = "Resurs Manager" };
            //    //var roleProjectManager = new Role() { Name = "Project Manager" };
            //    //var roleEmployee = new Role() { Name = "Employee" };

            //    context.Roles.Add(roleAdmin);
            //    context.Roles.Add(roleResursManager);
            //    context.Roles.Add(roleProjectManager);
            //    context.Roles.Add(roleEmployee);
            //    context.SaveChanges();

            //}
            //!Q2w3e4r5t
           // if (!context.Users.Any(u => u.Roles.Contains("Admin"))
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

                if (!roleManager.RoleExists("Member"))
                {
                    roleManager.Create(new IdentityRole("Member"));
                }

                var user = new User();
                user.FirstName = "Admin";
                user.LastName = "Marlabs";
                user.Email = "admin@marlabs.com";
                user.UserName = "admin@marlabs.com";

                var userResult = userManager.Create(user, "Marlabs");

                if (userResult.Succeeded)
                {
                    var user1 = userManager.FindByName("admin@marlabs.com");
                    userManager.AddToRole(user1.Id, "Admin");
                }

                //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                //if (!roleManager.RoleExists("Admin"))
                //{
                //    roleManager.Create(new IdentityRole("Admin"));
                //}

                //var userAdmin = new User()
                //{
                //    FirstName = "Dmitry",
                //    LastName = "Bush",
                //    Email = "BushDmitry2@gmail.com",
                //    DateCreated = DateTime.Now,
                //    PhoneNumber = "+375298801935",
                //    Salt = "xhDwV1V41xTfbhgCue453g==",
                //    HashedPassword = "bUvR54QvpsV8/J3oy/MoiThU4zeKkf4tPY/ZQbUJoDc=",
                //   // Role = roleManager.Roles();                  

                //};

                //var userManager = new UserManager<User>(new UserStore<User>(context));
                //var userResult = userManager.Create(userAdmin, "Dmitry");

                //if (userResult.Succeeded)
                //{

                //    userManager.AddToRoleAsync<User>(userAdmin.Id, "Admin");
                //}
                //context.Users.Add(userAdmin);
                //context.SaveChanges();
            }
        }
    }
}
