namespace EEP.DAL
{
    using EEP.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EEPDbContext : IdentityDbContext<User>
    {
        public EEPDbContext()
            : base("EEPDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EEPDbContext, Migrations.Configuration>(true));
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ParticipationHistoryInProject> ParticipationHistoryInProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<ParticipationHistoryInProject>().ToTable("ParticipationHistoryInProjects");


        }


        public static EEPDbContext Create()
        {
            return new EEPDbContext();
        }

    }
}

