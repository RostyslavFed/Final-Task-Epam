using System.Collections.Generic;

namespace Hospital.WEB.Models.ViewModels.CategoryViewModels
{
	public class CategoryListViewModel
	{
		public IEnumerable<CategoryViewModel> Categories { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}