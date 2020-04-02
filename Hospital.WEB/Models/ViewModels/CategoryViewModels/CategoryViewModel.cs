using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital.WEB.Models.ViewModels.CategoryViewModels
{
	public class CategoryViewModel
	{
		[HiddenInput]
		public int Id { get; set; }

		[Required(ErrorMessage = "Required field Name")]
		[StringLength(20, ErrorMessage = "Name must be between 3 and 20 characters", MinimumLength = 3)]
		public string Name { get; set; }
	}
}