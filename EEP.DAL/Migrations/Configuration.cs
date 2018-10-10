namespace EEP.DAL.Migrations
{
    using EEP.Entities;
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
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {

                var roleAdmin = new Role() { Name = "Admin" };
                var roleResursManager = new Role() { Name = "Resurs Manager" };
                var roleProjectManager = new Role() { Name = "Project Manager" };
                var roleEmployee = new Role() { Name = "Employee" };

                context.Roles.Add(roleAdmin);
                context.Roles.Add(roleResursManager);
                context.Roles.Add(roleProjectManager);
                context.Roles.Add(roleEmployee);
                context.SaveChanges();

            }
            //!Q2w3e4r5t
            if (!context.Users.Any(u => u.Role.Name == "Admin"))
            {

                var userAdmin = new User()
                {
                    FirstName = "Dmitry",
                    LastName = "Bush",
                    Email = "BushDmitry@gmail.com", 
                    DateCreated = DateTime.Now,
                    PhoneNumber = "+375298801935",
                    Salt = "xhDwV1V41xTfbhgCue453g==",
                    HashedPassword = "bUvR54QvpsV8/J3oy/MoiThU4zeKkf4tPY/ZQbUJoDc=",
                    Role = context.Roles.First(r=> r.Name == "Admin")                   

                };

                context.Users.Add(userAdmin);
                context.SaveChanges();
            }
        }
    }
}
