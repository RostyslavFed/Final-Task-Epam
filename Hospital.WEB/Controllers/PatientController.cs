using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Hospital.BLL.BusinessModels;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models;
using Hospital.WEB.Models.ViewModels.PatientViewModels;

namespace Hospital.WEB.Controllers
{
    [Authorize(Roles = "admin,patient,nurse")]
    public class PatientController : Controller
    {
        private readonly IViewModelFactory<IEnumerable<PatientDTO>, PatientListViewModel> _patientListViewModelFactory;
        private readonly IPatientService _patientService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IViewModelFactory<PatientDTO, PatientViewModel> _patientViewModelFactory;

        public PatientController(IPatientService patientService, IEmployeeService employeeService, IMapper mapper,
            IViewModelFactory<IEnumerable<PatientDTO>, PatientListViewModel> patientListViewModelFactory,
            IViewModelFactory<PatientDTO, PatientViewModel> patientViewModelFactory)
        {
            _patientListViewModelFactory = patientListViewModelFactory;
            _patientViewModelFactory = patientViewModelFactory;
            _patientService = patientService;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: Patient
        [Authorize(Roles = "admin,doctor,nurse")]
        public ActionResult List(PatientSort patientSort = PatientSort.AlphabetAscending, int page = 1)
        {
            const int pageSize = 10;

            var patients = _patientService.GetPatients(patientSort);
            var pageInfo = new PageInfo(page, pageSize, patients.ToList().Count);
            var patientsPerPage = patients.Skip((pageInfo.PageNumber - 1) * pageSize).Take(pageSize);
            var patientListViewModel = _patientListViewModelFactory.Create(patientsPerPage);
            patientListViewModel.PageInfo = pageInfo;
            patientListViewModel.PatientSort = patientSort;

            return View(patientListViewModel);
        }

        // GET: Patient/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            var patient = new PatientDTO();
            var patientViewModel = _patientViewModelFactory.Create(patient);

            return View(patientViewModel);
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(PatientViewModel patientViewModel)
        {
            #region Validation
            //валидация дня рождения
            //if (patientViewModel.Birthday > patientViewModel.MaxDate)
            //{
            //    ModelState.AddModelError(nameof(PatientViewModel.Birthday), "Age should be over 14 years");
            //}
            //if (patientViewModel.Birthday < patientViewModel.MinDate)
            //{
            //    ModelState.AddModelError(nameof(PatientViewModel.Birthday), "Age should be less than 120 years");
            //}

            //валидация рабочего(врача)
            if (_employeeService.GetEmployee(patientViewModel.EmployeeId.Value) == null)
            {
                ModelState.AddModelError(nameof(PatientDTO.EmployeeId), "Nonexistent Employee");
            }
            #endregion

            var patient = _mapper.Map<PatientDTO>(patientViewModel);
            if (ModelState.IsValid)
            {
                _patientService.CreatePatient(patient);
                return RedirectToAction("Index");
            }
            else
            {
                patientViewModel = _patientViewModelFactory.Create(patient);

                return View(patientViewModel);
            }
        }

        // GET: Patient/Edit/
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var patientDTO = _patientService.GetPatient(id);
            if (patientDTO == null)
            {
                return HttpNotFound();
            }

            var patientViewModel = _patientViewModelFactory.Create(patientDTO);

            return View(patientViewModel);
        }

        // POST: Patient/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(PatientViewModel patientViewModel)
        {
            #region Validation
            //валидация дня рождения
            //if (patientViewModel.Birthday > patientViewModel.MaxDate)
            //{
            //    ModelState.AddModelError(nameof(PatientViewModel.Birthday), "Age should be over 14 years");
            //}
            //if (patientViewModel.Birthday < patientViewModel.MinDate)
            //{
            //    ModelState.AddModelError(nameof(PatientViewModel.Birthday), "Age should be less than 120 years");
            //}

            //валидация рабочего(врача)
            if (_employeeService.GetEmployee(patientViewModel.EmployeeId.Value) == null)
            {
                ModelState.AddModelError(nameof(PatientDTO.EmployeeId), "Nonexistent Employee");
            }
            #endregion

            var patient = _mapper.Map<PatientDTO>(patientViewModel);
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(patient);
                return RedirectToAction("Index");
            }
            else
            {
                patientViewModel = _patientViewModelFactory.Create(patient);

                return View(patientViewModel);
            }
        }

        // GET: Patient/Delete/
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var patientDTO = _patientService.GetPatient(id);
            if (patientDTO == null) return HttpNotFound();
            return View(patientDTO);
        }

        // POST: Patient/Delete/
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            var patientDTO = _patientService.GetPatient(id);
            _patientService.DeletePatient(patientDTO.Id);
            return RedirectToAction("Index");
        }

        // GET: Patient/Details/
        [Authorize(Roles = "admin,doctor,nurse")]
        public ActionResult Details(int id)
        {
            var patientDTO = _patientService.GetPatient(id);
            if (patientDTO == null) return HttpNotFound();
            return View(patientDTO);
        }
    }
}
