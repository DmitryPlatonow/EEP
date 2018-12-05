namespace EEP.DAL
{
    using EEP.DAL.Interfaces;
    using EEP.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EEPDbContext :  IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public EEPDbContext()
            : base("EEPDbContext")
        {
            //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<EEPDbContext, Migrations.Configuration>(true));
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectParticipationHistory> ParticipationHistoryInProjects { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");


            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<Project>().ToTable("Projects");
            //modelBuilder.Entity<ProjectParticipationHistory>().ToTable("ProjectParticipationHistorys");

        }


        public static EEPDbContext Create()
        {
            return new EEPDbContext();
        }

    }

}

