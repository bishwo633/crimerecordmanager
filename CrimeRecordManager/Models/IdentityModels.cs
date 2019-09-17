using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CrimeRecordManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.Designation> Designations { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.ChargeSheet> ChargeSheets { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.Fir> Firs { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.ComplaintRegistration> ComplaintRegistrations { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.Crime> Crimes { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.CrimeDetail> CrimeDetails { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.CriminalDetails> CriminalDetails { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.PoliceStation> PoliceStations { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.EvidenceDetails> EvidenceDetails { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.Investigation> Investigations { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.VictimDetails> VictimDetails { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.WitnessDetails> WitnessDetails { get; set; }

        public System.Data.Entity.DbSet<CrimeRecordManager.Models.AccusedDetail> AccusedDetails { get; set; }
    }
}