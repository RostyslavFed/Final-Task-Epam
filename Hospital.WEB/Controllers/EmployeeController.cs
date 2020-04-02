using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models;
using Hospital.BLL.BusinessModels;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;

namespace Hospital.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IViewModelFactory<IEnumerable<EmployeeDTO>, EmployeeListViewModel> _employeeListViewModelFactory;
        private readonly IViewModelFactory<EmployeeDTO, EmployeeCreateViewModel> _employeeCreateViewModelFactory;
        private readonly IViewModelFactory<EmployeeDTO, EmployeeEditViewModel> _employeeEditViewModelFactory;
        private readonly IViewModelFactory<EmployeeDTO, EmployeeViewModel> _employeeViewModelFactory;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper,
            IViewModelFactory<IEnumerable<EmployeeDTO>, EmployeeListViewModel> employeeListViewModelFactory,
            IViewModelFactory<EmployeeDTO, EmployeeCreateViewModel> employeeCreateViewModelFactory,
            IViewModelFactory<EmployeeDTO, EmployeeEditViewModel> employeeEditViewModelFactory,
            IViewModelFactory<EmployeeDTO, EmployeeViewModel> employeeViewModelFactory)
        {
            _employeeListViewModelFactory = employeeListViewModelFactory;
            _employeeCreateViewModelFactory = employeeCreateViewModelFactory;
            _employeeEditViewModelFactory = employeeEditViewModelFactory;

            _employeeViewModelFactory = employeeViewModelFactory;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult List(EmployeeSort employeeSort = EmployeeSort.AlphabetAscending, int page = 1)
        {
            const int pageSize = 1;

            IEnumerable<EmployeeDTO> employees = _employeeService.GetStaff(employeeSort);

            var pageInfo = new PageInfo(page, pageSize, employees.ToList().Count);
            var employeesPerPage = employees.Skip((pageInfo.PageNumber - 1) * pageSize).Take(pageSize);

            var employeeListViewModel = _employeeListViewModelFactory.Create(employeesPerPage);
            employeeListViewModel.PageInfo = pageInfo;
            employeeListViewModel.EmployeeSort = employeeSort;

            return View(employeeListViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var employee = new EmployeeDTO();
            var employeeCreateViewModel = _employeeCreateViewModelFactory.Create(employee);

            return View(employeeCreateViewModel);
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel employeeCreateViewModel)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeCreateViewModel);
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                return RedirectToAction("List");
            }
            employeeCreateViewModel = _employeeCreateViewModelFactory.Create(employee);

            return View(employeeCreateViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeEditViewModel = _employeeEditViewModelFactory.Create(employee);

            return View(employeeEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel employeeEditViewModel)
        {
            var employee = _mapper.Map<EmployeeDTO>(employeeEditViewModel);

            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("List");
            }

            employeeEditViewModel = _employeeEditViewModelFactory.Create(employee);
            return View(employeeEditViewModel);
        }

    }
}