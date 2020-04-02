using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Identity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;
        private CategoryRepository _categoryRepository;
        private DiagnoseRepository _diagnoseRepository;
        private ExaminationRepository _examinationRepository;
        private MedicineRepository _medicineRepository;
        private OperationRepository _operationRepository;
        private PatientRepository _patientRepository;
        private ProcedureRepository _procedureRepository;
        private EmployeeRepository _employeeRepository;
        private UserManager _userManager;
        private RoleManager _roleManager;
        private LogRepository _logRepository;

        public UnitOfWork(string connectionString)
        {
            _hospitalContext = new HospitalContext(connectionString);
        }

        public UnitOfWork(string connectionString, IMapper mapper)
        {
            _hospitalContext = new HospitalContext(connectionString);
            _mapper = mapper;
        }

        public UserManager UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = new UserManager(_hospitalContext);
                }
                return _userManager;
            }
        }

        public RoleManager RoleManager
        {
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new RoleManager(_hospitalContext);
                }
                return _roleManager;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_hospitalContext, _mapper);
                }
                return _categoryRepository;
            }
        }

        public IRepository<Diagnose> Diagnoses
        {
            get
            {
                if (_diagnoseRepository == null)
                {
                    _diagnoseRepository = new DiagnoseRepository(_hospitalContext, _mapper);
                }
                return _diagnoseRepository;
            }
        }

        public IRepository<Examination> Examinations
        {
            get
            {
                if (_examinationRepository == null)
                {
                    _examinationRepository = new ExaminationRepository(_hospitalContext, _mapper);
                }
                return _examinationRepository;
            }
        }

        public IRepository<Medicine> Medicines
        {
            get
            {
                if (_medicineRepository == null)
                {
                    _medicineRepository = new MedicineRepository(_hospitalContext, _mapper);
                }
                return _medicineRepository;
            }
        }

        public IRepository<Operation> Operations
        {
            get
            {
                if (_operationRepository == null)
                {
                    _operationRepository = new OperationRepository(_hospitalContext, _mapper);
                }
                return _operationRepository;
            }
        }

        public IRepository<Patient> Patients
        {
            get
            {
                if (_patientRepository == null)
                {
                    _patientRepository = new PatientRepository(_hospitalContext, _mapper);
                }
                return _patientRepository;
            }
        }

        public IRepository<Procedure> Procedures
        {
            get
            {
                if (_procedureRepository == null)
                {
                    _procedureRepository = new ProcedureRepository(_hospitalContext, _mapper);
                }
                return _procedureRepository;
            }
        }

        public IRepository<Employee> Staff
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_hospitalContext, _mapper);
                }
                return _employeeRepository;
            }
        }

        public IRepository<Log> Logs
        {
            get
            {
                if (_logRepository == null)
                {
                    _logRepository = new LogRepository(_hospitalContext, _mapper);
                }
                return _logRepository;
            }
        }

        public void Save()
        {
            _hospitalContext.SaveChanges();
        }
    }
}