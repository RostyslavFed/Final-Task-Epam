using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.PatientViewModels;
using System.Collections.Generic;

namespace Hospital.WEB.Factories.Patient
{
	public class PatientListViewModelFactory : IViewModelFactory<IEnumerable<PatientDTO>, PatientListViewModel>
	{
		private readonly IMapper _mapper;

		public PatientListViewModelFactory(IMapper mapper)
		{
			_mapper = mapper;
		}

		public PatientListViewModel Create(IEnumerable<PatientDTO> model)
		{
			var listPatientViewModels = _mapper.Map<IEnumerable<PatientViewModel>>(model);
			var patientListViewModel = new PatientListViewModel
			{
				Patients = listPatientViewModels
			};

			return patientListViewModel;
		}
	}
}