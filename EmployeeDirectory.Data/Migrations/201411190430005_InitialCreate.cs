namespace EmployeeDirectory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeNo = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Title = c.String(maxLength: 100),
                        OfficeId = c.String(maxLength: 5),
                        VacationHours = c.Int(nullable: false),
                        ChangeUser = c.String(nullable: false, maxLength: 256),
                        ChangeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeNo)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        OfficeId = c.String(nullable: false, maxLength: 5),
                        OfficeName = c.String(nullable: false, maxLength: 100),
                        City = c.String(maxLength: 100),
                        State = c.String(maxLength: 2),
                        ChangeUser = c.String(nullable: false, maxLength: 256),
                        ChangeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OfficeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "OfficeId", "dbo.Office");
            DropIndex("dbo.Employee", new[] { "OfficeId" });
            DropTable("dbo.Office");
            DropTable("dbo.Employee");
        }
    }
}
