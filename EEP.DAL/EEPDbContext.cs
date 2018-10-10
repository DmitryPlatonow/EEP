namespace EEP.DAL
{
    using EEP.Entities;
    using System.Data.Entity;

    public class EEPDbContext : DbContext
    {
        public EEPDbContext()
            : base("name=EEPDbContext")
        {
         //Database.SetInitializer<EEPDbContext>(null);
          Database.SetInitializer(new MigrateDatabaseToLatestVersion<EEPDbContext, Migrations.Configuration>(true));
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<HistoryParticipation> HistoryParticipations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<HistoryParticipation>().ToTable("ParticipationHistorys");
        }

    }
}

