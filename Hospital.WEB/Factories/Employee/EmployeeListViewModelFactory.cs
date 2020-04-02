using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;
using System.Collections.Generic;

namespace Hospital.WEB.Factories.Employee
{
	public class EmployeeListViewModelFactory : IViewModelFactory<IEnumerable<EmployeeDTO>, EmployeeListViewModel>
	{
		private readonly IMapper _mapper;
		public EmployeeListViewModelFactory(IMapper mapper)
		{
			_mapper = mapper;
		}

		public EmployeeListViewModel Create(IEnumerable<EmployeeDTO> model)
		{
			var listEmployeeViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(model);

			var employeeListViewModel = new EmployeeListViewModel
			{
				Employees = listEmployeeViewModel
			};

			return employeeListViewModel;
		}
	}
}