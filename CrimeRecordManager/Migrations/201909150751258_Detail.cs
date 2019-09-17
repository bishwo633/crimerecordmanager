namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Detail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PoliceStations", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.PoliceStations", new[] { "EmployeeId" });
            AddColumn("dbo.Employees", "PoliceStationId", c => c.Int(nullable: false));
            AddColumn("dbo.Investigations", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "PoliceStationId");
            CreateIndex("dbo.Investigations", "EmployeeId");
            AddForeignKey("dbo.Employees", "PoliceStationId", "dbo.PoliceStations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Investigations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropColumn("dbo.PoliceStations", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PoliceStations", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Investigations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "PoliceStationId", "dbo.PoliceStations");
            DropIndex("dbo.Investigations", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "PoliceStationId" });
            DropColumn("dbo.Investigations", "EmployeeId");
            DropColumn("dbo.Employees", "PoliceStationId");
            CreateIndex("dbo.PoliceStations", "EmployeeId");
            AddForeignKey("dbo.PoliceStations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
