namespace AM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Passes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Passes", new[] { "EmployeeId" });
            DropTable("dbo.Passes");
        }
    }
}
