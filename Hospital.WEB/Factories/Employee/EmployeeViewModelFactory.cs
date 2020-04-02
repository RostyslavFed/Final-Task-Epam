using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.EmployeeViewModels;
using System.Collections.Generic;
using Hospital.BLL.Interfaces;
using System.Web.Mvc;

namespace Hospital.WEB.Factories.Employee
{
	public class EmployeeViewModelFactory : IViewModelFactory<EmployeeDTO, EmployeeViewModel>
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		public EmployeeViewModelFactory(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public EmployeeViewModel Create(EmployeeDTO model)
		{
			var employeeViewModel = _mapper.Map<EmployeeViewModel>(model);
			var categories = _categoryService.GetCategories();

			//if (model == null)
			//{
			//	employeeViewModel.CategoriesDTO = new SelectList(categories,
			//											nameof(CategoryDTO.Id),
			//											nameof(CategoryDTO.Name));
			//}
			//else
			//{
			//	employeeViewModel.CategoriesDTO = new SelectList(categories,
			//											nameof(CategoryDTO.Id),
			//											nameof(CategoryDTO.Name),
			//											model.CategoryId);
			//}

			return employeeViewModel;
		}
	}
}