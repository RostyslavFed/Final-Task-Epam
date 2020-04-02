using System.Data.Entity;
using Hospital.DAL.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.DAL.EF
{
    public class HospitalContext : IdentityDbContext<User>
    {
        static HospitalContext()
        {
            Database.SetInitializer(new HospitalDbInitializer());
        }

        public HospitalContext()
            : base("HospitalContext")
        {
        }

        public HospitalContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Staff { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Diagnose> Diagnosis { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}