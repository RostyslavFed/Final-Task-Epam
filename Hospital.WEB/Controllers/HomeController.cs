using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using System.Web.Mvc;
using System;

namespace Hospital.WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPatientService _patientService;
		private readonly IEmployeeService _employeeService;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public HomeController(IPatientService patientService, IEmployeeService employeeService,
			IMapper mapper, IUserService userService)
		{
			_patientService = patientService;
			_employeeService = employeeService;
			_mapper = mapper;
			_userService = userService;
		}

		public ActionResult Index()
		{
			ViewBag.Message = "Your application main page.";

			UserDTO admin = new UserDTO
			{
				Birthday = DateTime.Now,
				Email = "admin@gmail.com",
				Gender = DAL.Entity.Gender.Male,
				Password = "adminadmin",
				PhoneNumber = "1234567890123",
				Role = "admin",
				UserName = "Administrator",
				Address = "admin_adress"
			};

			//_userService.Create(admin);

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}