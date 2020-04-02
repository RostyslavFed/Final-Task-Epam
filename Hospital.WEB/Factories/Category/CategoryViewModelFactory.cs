using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.CategoryViewModels;

namespace Hospital.WEB.Factories.Category
{
	public class CategoryViewModelFactory : IViewModelFactory<CategoryDTO, CategoryViewModel>
	{
		public readonly IMapper _mapper;
		public CategoryViewModelFactory(IMapper mapper)
		{
			_mapper = mapper;
		}

		public CategoryViewModel Create(CategoryDTO model)
		{
			return _mapper.Map<CategoryViewModel>(model);
		}
	}
}