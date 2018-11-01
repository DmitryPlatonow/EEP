namespace EEP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ParticipationHistoryInProjects", newName: "ProjectParticipationHistorys");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProjectParticipationHistorys", newName: "ParticipationHistoryInProjects");
        }
    }
}
