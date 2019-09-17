namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accused : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccusedDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccusedName = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Gender = c.Int(),
                        OthersDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ComplaintRegistrations", "AccusedDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.WitnessDetails", "Gender", c => c.Int());
            AlterColumn("dbo.CriminalDetails", "Gender", c => c.Int());
            AlterColumn("dbo.EvidenceDetails", "Description", c => c.String(maxLength: 400));
            AlterColumn("dbo.VictimDetails", "Gender", c => c.Int());
            CreateIndex("dbo.ComplaintRegistrations", "AccusedDetailId");
            AddForeignKey("dbo.ComplaintRegistrations", "AccusedDetailId", "dbo.AccusedDetails", "Id", cascadeDelete: true);
            DropColumn("dbo.ComplaintRegistrations", "AccusedName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComplaintRegistrations", "AccusedName", c => c.String());
            DropForeignKey("dbo.ComplaintRegistrations", "AccusedDetailId", "dbo.AccusedDetails");
            DropIndex("dbo.ComplaintRegistrations", new[] { "AccusedDetailId" });
            AlterColumn("dbo.VictimDetails", "Gender", c => c.String());
            AlterColumn("dbo.EvidenceDetails", "Description", c => c.String());
            AlterColumn("dbo.CriminalDetails", "Gender", c => c.String());
            DropColumn("dbo.WitnessDetails", "Gender");
            DropColumn("dbo.ComplaintRegistrations", "AccusedDetailId");
            DropTable("dbo.AccusedDetails");
        }
    }
}
