namespace CrimeRecordManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrimeRecordManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CrimeRecordManager.Models.ApplicationDbContext";
        }

        protected override void Seed(CrimeRecordManager.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "1",
                Name = "Admin"
            });
            context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "2",
                Name = "Officer"
            });
            context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            {
                Id = "3",
                Name = "Writer"
            });
            context.SaveChanges();
        }
    }
}
