using Hospital.DAL.Entity;
using Hospital.DAL.Identity;

namespace Hospital.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Diagnose> Diagnoses { get; }
        IRepository<Examination> Examinations { get; }
        IRepository<Medicine> Medicines { get; }
        IRepository<Operation> Operations { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Procedure> Procedures { get; }
        IRepository<Employee> Staff { get; }
        UserManager UserManager { get; }
        RoleManager RoleManager { get; }
        IRepository<Log> Logs { get; }
        void Save();
    }
}