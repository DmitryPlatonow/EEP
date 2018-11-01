namespace EEP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectParticipationHistorys", "StartDateParticipation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ProjectParticipationHistorys", "EndDateParticipation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ProjectParticipationHistorys", "RealEndDateParticipation", c => c.DateTime());
            AddColumn("dbo.Projects", "ProjectName", c => c.String(maxLength: 75));
            AddColumn("dbo.Projects", "StartProjectDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Projects", "EndProjectDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.ProjectParticipationHistorys", "StartDate");
            DropColumn("dbo.ProjectParticipationHistorys", "EndDate");
            DropColumn("dbo.ProjectParticipationHistorys", "RealEndDate");
            DropColumn("dbo.Projects", "Name");
            DropColumn("dbo.Projects", "StartDate");
            DropColumn("dbo.Projects", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Projects", "Name", c => c.String(maxLength: 75));
            AddColumn("dbo.ProjectParticipationHistorys", "RealEndDate", c => c.DateTime());
            AddColumn("dbo.ProjectParticipationHistorys", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ProjectParticipationHistorys", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Projects", "EndProjectDate");
            DropColumn("dbo.Projects", "StartProjectDate");
            DropColumn("dbo.Projects", "ProjectName");
            DropColumn("dbo.ProjectParticipationHistorys", "RealEndDateParticipation");
            DropColumn("dbo.ProjectParticipationHistorys", "EndDateParticipation");
            DropColumn("dbo.ProjectParticipationHistorys", "StartDateParticipation");
        }
    }
}
