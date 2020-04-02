using Hospital.DAL.Entity;
using Hospital.DAL.Identity;
using System.Data.Entity;

namespace Hospital.DAL.EF
{
    public class HospitalDbInitializer : DropCreateDatabaseIfModelChanges<HospitalContext>
    {
        protected override void Seed(HospitalContext hospitalContext)
        {
            var adminRole = new Role("admin");
            var employeeRole = new Role("doctor");
            var nurseRole = new Role("nurse");
            var patientRole = new Role("patient");

            var roleManager = new RoleManager(hospitalContext);
            roleManager.CreateAsync(adminRole);
            roleManager.CreateAsync(employeeRole);
            roleManager.CreateAsync(nurseRole);
            roleManager.CreateAsync(patientRole);


            //var userManager = new UserManager(hospitalContext);
            //userManager.CreateAsync()

            Category c = new Category
            {
                Name = "Doctor"
            };

            hospitalContext.Categories.Add(c);


            hospitalContext.SaveChanges();
        }
    }
}