using Ninject.Modules;
using Hospital.BLL.DTO;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.CategoryViewModels;
using System.Collections.Generic;
using Hospital.WEB.Factories.Category;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;
using Hospital.WEB.Factories.Employee;
using Hospital.WEB.Factories.Patient;
using Hospital.WEB.Models.ViewModels.PatientViewModels;

namespace Hospital.WEB.Util
{
	public class FactoryModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IViewModelFactory<IEnumerable<CategoryDTO>, CategoryListViewModel>>()
				.To<CategoryListViewModelFactory>();
			Bind<IViewModelFactory<CategoryDTO, CategoryViewModel>>()
				.To<CategoryViewModelFactory>();

			Bind<IViewModelFactory<IEnumerable<EmployeeDTO>, EmployeeListViewModel>>()
				.To<EmployeeListViewModelFactory>();
			Bind<IViewModelFactory<EmployeeDTO, EmployeeCreateViewModel>>()
				.To<EmployeeCreateViewModelFactory>();
			Bind<IViewModelFactory<EmployeeDTO, EmployeeEditViewModel>>()
				.To<EmployeeEditViewModelFactory>();
			Bind<IViewModelFactory<EmployeeDTO, EmployeeViewModel>>()
				.To<EmployeeViewModelFactory>();

			Bind<IViewModelFactory<IEnumerable<PatientDTO>, PatientListViewModel>>()
				.To<PatientListViewModelFactory>();

		}
	}
}