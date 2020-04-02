using Hospital.BLL.DTO;
using System.Collections.Generic;

namespace Hospital.WEB.Models.ViewModels.LogViewModels
{
	public class LogListViewModel
	{
		public PageInfo PageInfo { get; set; }
		public IEnumerable<LogDTO> Logs { get; set; }
	}
}