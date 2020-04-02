using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;
using System.Web.Mvc;

namespace Hospital.WEB.Factories.Employee
{
	public class EmployeeEditViewModelFactory : IViewModelFactory<EmployeeDTO, EmployeeEditViewModel>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public EmployeeEditViewModelFactory(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public EmployeeEditViewModel Create(EmployeeDTO model)
		{
			var employeeEditViewModel = _mapper.Map<EmployeeEditViewModel>(model);
			var categories = _categoryService.GetCategories();

			employeeEditViewModel.CategoriesDTO = new SelectList(categories,
																 nameof(CategoryDTO.Id),
																 nameof(CategoryDTO.Name),
																 model.CategoryId);

			return employeeEditViewModel;
		}
	}
}