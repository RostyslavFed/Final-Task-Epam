using Hospital.BLL.Interfaces;
using Hospital.BLL.Services;
using Ninject.Modules;

namespace Hospital.WEB.Util
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IPatientService>().To<PatientService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IMedicineService>().To<MedicineService>();
            Bind<IProcedureService>().To<ProcedureService>();
            Bind<IOperationService>().To<OperationService>();
            Bind<IDiagnosisService>().To<DiagnosisService>();
            Bind<IExaminationService>().To<ExaminationService>();
            Bind<ILogService>().To<LogService>();
        }
    }
}