using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.CategoryViewModels;
using System.Collections.Generic;

namespace Hospital.WEB.Factories.Category
{
	public class CategoryListViewModelFactory : IViewModelFactory<IEnumerable<CategoryDTO>, CategoryListViewModel>
	{
		private readonly IMapper _mapper;
		public CategoryListViewModelFactory(IMapper mapper)
		{
			_mapper = mapper;
		}

		public CategoryListViewModel Create(IEnumerable<CategoryDTO> model)
		{
			var listCategoryViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(model);

			var categoryListViewModel = new CategoryListViewModel
			{
				Categories = listCategoryViewModel
			};

			return categoryListViewModel;
		}
	}
}