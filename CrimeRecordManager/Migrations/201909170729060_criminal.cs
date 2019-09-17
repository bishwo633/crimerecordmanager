namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criminal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccusedDetails", "Age");
            DropColumn("dbo.AccusedDetails", "Address");
            DropColumn("dbo.AccusedDetails", "Country");
            DropColumn("dbo.AccusedDetails", "Phone");
            DropColumn("dbo.AccusedDetails", "Email");
            DropColumn("dbo.AccusedDetails", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccusedDetails", "Gender", c => c.Int());
            AddColumn("dbo.AccusedDetails", "Email", c => c.String());
            AddColumn("dbo.AccusedDetails", "Phone", c => c.String());
            AddColumn("dbo.AccusedDetails", "Country", c => c.String());
            AddColumn("dbo.AccusedDetails", "Address", c => c.String());
            AddColumn("dbo.AccusedDetails", "Age", c => c.Int(nullable: false));
        }
    }
}
