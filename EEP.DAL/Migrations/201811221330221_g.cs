namespace EEP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectParticipationHistorys", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ProjectParticipationHistorys", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Employees", new[] { "Project_ProjectId" });
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.ProjectParticipationHistorys", new[] { "EmployeeId" });
            DropPrimaryKey("dbo.ProjectParticipationHistorys");
            AddColumn("dbo.ProjectParticipationHistorys", "EmployeeRoleInProject", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectParticipationHistorys", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Users", "Project_ProjectId", c => c.Int());
            AlterColumn("dbo.ProjectParticipationHistorys", "StartDateParticipation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectParticipationHistorys", "EndDateParticipation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectParticipationHistorys", "RealEndDateParticipation", c => c.DateTime());
            AlterColumn("dbo.Projects", "StartProjectDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "EndProjectDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.ProjectParticipationHistorys", "ProjectId");
            CreateIndex("dbo.ProjectParticipationHistorys", "User_Id");
            CreateIndex("dbo.Users", "Project_ProjectId");
            AddForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects", "ProjectId");
            AddForeignKey("dbo.ProjectParticipationHistorys", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.ProjectParticipationHistorys", "ProjectId", "dbo.Projects", "ProjectId");
            DropColumn("dbo.ProjectParticipationHistorys", "EmployeeId");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeRoleInProject = c.Int(nullable: false),
                        Project_ProjectId = c.Int(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProjectParticipationHistorys", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProjectParticipationHistorys", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectParticipationHistorys", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "Project_ProjectId" });
            DropIndex("dbo.ProjectParticipationHistorys", new[] { "User_Id" });
            DropPrimaryKey("dbo.ProjectParticipationHistorys");
            AlterColumn("dbo.Projects", "EndProjectDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Projects", "StartProjectDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ProjectParticipationHistorys", "RealEndDateParticipation", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.ProjectParticipationHistorys", "EndDateParticipation", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ProjectParticipationHistorys", "StartDateParticipation", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Users", "Project_ProjectId");
            DropColumn("dbo.ProjectParticipationHistorys", "User_Id");
            DropColumn("dbo.ProjectParticipationHistorys", "EmployeeRoleInProject");
            AddPrimaryKey("dbo.ProjectParticipationHistorys", new[] { "EmployeeId", "ProjectId" });
            CreateIndex("dbo.ProjectParticipationHistorys", "EmployeeId");
            CreateIndex("dbo.Employees", "User_Id");
            CreateIndex("dbo.Employees", "Project_ProjectId");
            AddForeignKey("dbo.ProjectParticipationHistorys", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "Project_ProjectId", "dbo.Projects", "ProjectId");
            AddForeignKey("dbo.ProjectParticipationHistorys", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
