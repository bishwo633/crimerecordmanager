namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fir : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investigations", "InvestigationDetails", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Investigations", "InvestigationDetails", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
