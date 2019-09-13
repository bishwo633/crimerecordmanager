namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gender_employee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Gender", c => c.String());
        }
    }
}
