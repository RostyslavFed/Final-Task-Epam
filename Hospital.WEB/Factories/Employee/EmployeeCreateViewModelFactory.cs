using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;
using System.Web.Mvc;

namespace Hospital.WEB.Factories.Employee
{
	public class EmployeeCreateViewModelFactory : IViewModelFactory<EmployeeDTO, EmployeeCreateViewModel>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;
		public EmployeeCreateViewModelFactory(IMapper mapper, ICategoryService categoryService)
		{
			_mapper = mapper;
			_categoryService = categoryService;
		}

		public EmployeeCreateViewModel Create(EmployeeDTO model)
		{
			var employeeCreateViewModel = _mapper.Map<EmployeeCreateViewModel>(model);
			var categories = _categoryService.GetCategories();

			if (model == null)
			{
				employeeCreateViewModel.CategoriesDTO = new SelectList(categories, 
																	   nameof(CategoryDTO.Id),
																	   nameof(CategoryDTO.Name));
			}
			else
			{
				employeeCreateViewModel.CategoriesDTO = new SelectList(categories,
																	   nameof(CategoryDTO.Id),
																	   nameof(CategoryDTO.Name),
																	   model.CategoryId);
			}

			return employeeCreateViewModel;
		}
	}
}