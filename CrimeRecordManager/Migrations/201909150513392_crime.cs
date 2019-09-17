namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChargeSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChargeSheetDetails = c.String(nullable: false, maxLength: 300),
                        ChargeSheetIssueDate = c.DateTime(nullable: false),
                        ChargeSheetBy = c.String(),
                        FirId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Firs", t => t.FirId, cascadeDelete: true)
                .Index(t => t.FirId);
            
            CreateTable(
                "dbo.Firs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationDetails = c.String(nullable: false, maxLength: 100),
                        RegistrationDate = c.DateTime(nullable: false),
                        CrimeDate = c.DateTime(nullable: false),
                        CrimeDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CrimeDetails", t => t.CrimeDetailId, cascadeDelete: true)
                .Index(t => t.CrimeDetailId);
            
            CreateTable(
                "dbo.CrimeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrimeType = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 400),
                        CrimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Crimes", t => t.CrimeId, cascadeDelete: true)
                .Index(t => t.CrimeId);
            
            CreateTable(
                "dbo.Crimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrimesName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 400),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComplaintRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplainBy = c.String(nullable: false, maxLength: 100),
                        CitizenshipNo = c.String(),
                        PhoneNumber = c.String(),
                        ComplainDate = c.DateTime(nullable: false),
                        AccusedName = c.String(),
                        ComplainDetails = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CriminalDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CriminalName = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Status = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        OldRecord = c.String(maxLength: 300),
                        PoliceStationId = c.Int(nullable: false),
                        CrimeDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CrimeDetails", t => t.CrimeDetailId, cascadeDelete: true)
                .ForeignKey("dbo.PoliceStations", t => t.PoliceStationId, cascadeDelete: true)
                .Index(t => t.PoliceStationId)
                .Index(t => t.CrimeDetailId);
            
            CreateTable(
                "dbo.PoliceStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PoliceStationName = c.String(nullable: false, maxLength: 100),
                        StartingDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        ComplaintRegistrationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComplaintRegistrations", t => t.ComplaintRegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ComplaintRegistrationId);
            
            CreateTable(
                "dbo.EvidenceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvidenceName = c.String(nullable: false, maxLength: 100),
                        EvidenceType = c.String(),
                        EvidenceFindingDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        InvestigationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Investigations", t => t.InvestigationId, cascadeDelete: true)
                .Index(t => t.InvestigationId);
            
            CreateTable(
                "dbo.Investigations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvestigationDetails = c.String(nullable: false, maxLength: 100),
                        InvestigationStartDate = c.DateTime(nullable: false),
                        InvestigationEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VictimDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VictimName = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        OthersDetails = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WitnessDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WitnessName = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvidenceDetails", "InvestigationId", "dbo.Investigations");
            DropForeignKey("dbo.CriminalDetails", "PoliceStationId", "dbo.PoliceStations");
            DropForeignKey("dbo.PoliceStations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PoliceStations", "ComplaintRegistrationId", "dbo.ComplaintRegistrations");
            DropForeignKey("dbo.CriminalDetails", "CrimeDetailId", "dbo.CrimeDetails");
            DropForeignKey("dbo.ChargeSheets", "FirId", "dbo.Firs");
            DropForeignKey("dbo.Firs", "CrimeDetailId", "dbo.CrimeDetails");
            DropForeignKey("dbo.CrimeDetails", "CrimeId", "dbo.Crimes");
            DropIndex("dbo.EvidenceDetails", new[] { "InvestigationId" });
            DropIndex("dbo.PoliceStations", new[] { "ComplaintRegistrationId" });
            DropIndex("dbo.PoliceStations", new[] { "EmployeeId" });
            DropIndex("dbo.CriminalDetails", new[] { "CrimeDetailId" });
            DropIndex("dbo.CriminalDetails", new[] { "PoliceStationId" });
            DropIndex("dbo.CrimeDetails", new[] { "CrimeId" });
            DropIndex("dbo.Firs", new[] { "CrimeDetailId" });
            DropIndex("dbo.ChargeSheets", new[] { "FirId" });
            DropTable("dbo.WitnessDetails");
            DropTable("dbo.VictimDetails");
            DropTable("dbo.Investigations");
            DropTable("dbo.EvidenceDetails");
            DropTable("dbo.PoliceStations");
            DropTable("dbo.CriminalDetails");
            DropTable("dbo.ComplaintRegistrations");
            DropTable("dbo.Crimes");
            DropTable("dbo.CrimeDetails");
            DropTable("dbo.Firs");
            DropTable("dbo.ChargeSheets");
        }
    }
}
