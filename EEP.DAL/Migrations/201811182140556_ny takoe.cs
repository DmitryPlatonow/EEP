namespace EEP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nytakoe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeRoleInProject", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectParticipationHistorys", "StartDateParticipation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectParticipationHistorys", "EndDateParticipation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectParticipationHistorys", "RealEndDateParticipation", c => c.DateTime());
            AlterColumn("dbo.Projects", "StartProjectDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "EndProjectDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "EmployeeRoleInProject");
            DropColumn("dbo.Users", "IsLocked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsLocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "EmployeeRoleInProject", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "EndProjectDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Projects", "StartProjectDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ProjectParticipationHistorys", "RealEndDateParticipation", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.ProjectParticipationHistorys", "EndDateParticipation", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ProjectParticipationHistorys", "StartDateParticipation", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Employees", "EmployeeRoleInProject");
        }
    }
}
