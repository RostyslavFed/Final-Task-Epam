using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models;
using Hospital.WEB.Models.ViewModels.PatientViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Hospital.WEB.Factories.Patient
{
	public class PatientViewModelFactory : IViewModelFactory<PatientDTO, PatientViewModel>
	{
		private readonly IEmployeeService _employeeService;
		private readonly IMapper _mapper;

		public PatientViewModelFactory(IEmployeeService employeeService, IMapper mapper)
		{
			_employeeService = employeeService;
			_mapper = mapper;
		}

		public PatientViewModel Create(PatientDTO model)
		{
			var patientViewModel = _mapper.Map<PatientViewModel>(model);
			var staff = _employeeService.GetStaff();

			if (model == null)
			{
				patientViewModel.StaffDTO = new SelectList(staff, 
					nameof(EmployeeDTO.Id), 
					nameof(EmployeeDTO.UserName));
			}
			else
			{
				patientViewModel.StaffDTO = new SelectList(staff,
					nameof(EmployeeDTO.Id),
					nameof(EmployeeDTO.UserName),
					model.EmployeeId);
			}

			return patientViewModel;
		}
	}
}