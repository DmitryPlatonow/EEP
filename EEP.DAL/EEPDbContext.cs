namespace EEP.DAL
{
    using EEP.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class EEPDbContext : IdentityDbContext<User>
    {
        public EEPDbContext()
            : base("EEPDbContext")
        {
         //Database.SetInitializer<EEPDbContext>(null);
         // Database.SetInitializer(new MigrateDatabaseToLatestVersion<EEPDbContext, Migrations.Configuration>(false));
        }

      //  public virtual DbSet<User> Users { get; set; }
     //   public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ParticipationHistoryInProject> ParticipationHistoryInProject { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


          //  modelBuilder.Entity<IdentityRole>().ToTable("Roles");
          //  modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
          //  modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
           // modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLoginProviders");
            // modelBuilder.Entity<User>().ToTable("Users");
            //  modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<ParticipationHistoryInProject>().ToTable("ParticipationHistoryInProjects");


           // modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
         //   modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
        }

    }
}

