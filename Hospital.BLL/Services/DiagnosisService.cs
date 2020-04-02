using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiagnosisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateDiagnosis(DiagnoseDTO diagnoseDto)
        {
            var diagnose = _mapper.Map<Diagnose>(diagnoseDto);
            _unitOfWork.Diagnoses.Create(diagnose);
            _unitOfWork.Save();
        }

        public void DeleteDiagnosis(int id)
        {
            _unitOfWork.Diagnoses.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<DiagnoseDTO> GetDiagnoses()
        {
            var diagnoses = _unitOfWork.Diagnoses.GetAll().ToList();
            return _mapper.Map<IEnumerable<DiagnoseDTO>>(diagnoses);
        }

        public DiagnoseDTO GetDiagnosis(int id)
        {
            var diagnosis = _unitOfWork.Diagnoses.Get(id);
            return _mapper.Map<DiagnoseDTO>(diagnosis);
        }

        public bool NameExists(string name)
        {
            return _unitOfWork.Diagnoses.Find(c => c.Name.ToLower() == name.ToLower()).ToList().Count > 0;
        }

        public void UpdateDiagnosis(DiagnoseDTO diagnoseDTO)
        {
            var diagnosis = _mapper.Map<Diagnose>(diagnoseDTO);
            _unitOfWork.Diagnoses.Update(diagnosis);
            _unitOfWork.Save();
        }
    }
}