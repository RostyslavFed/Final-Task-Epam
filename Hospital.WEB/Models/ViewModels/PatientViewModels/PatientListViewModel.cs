using Hospital.BLL.BusinessModels;
using System.Collections.Generic;

namespace Hospital.WEB.Models.ViewModels.PatientViewModels
{
	public class PatientListViewModel
	{
		public IEnumerable<PatientViewModel> Patients { get; set; }
		public PageInfo PageInfo { get; set; }
		public PatientSort PatientSort { get; set; }
	}
}