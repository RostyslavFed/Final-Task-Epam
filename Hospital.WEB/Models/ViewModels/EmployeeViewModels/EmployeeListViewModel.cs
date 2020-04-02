using Hospital.BLL.BusinessModels;
using System.Collections.Generic;

namespace Hospital.WEB.Models.ViewModels.EmployeeViewModels
{
	public class EmployeeListViewModel
	{
		public IEnumerable<EmployeeViewModel> Employees { get; set; }
		public PageInfo PageInfo { get; set; }
		public EmployeeSort EmployeeSort { get; set; }
	}
}