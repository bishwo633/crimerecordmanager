namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
        }
    }
}
