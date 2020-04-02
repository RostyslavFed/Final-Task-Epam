using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
    public class ExaminationService : IExaminationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExaminationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateExamination(ExaminationDTO examinationDto)
        {
            var examination = _mapper.Map<Examination>(examinationDto);
            _unitOfWork.Examinations.Create(examination);
            _unitOfWork.Save();
        }

        public void DeletExamination(int id)
        {
            _unitOfWork.Examinations.Delete(id);
            _unitOfWork.Save();
        }

        public ExaminationDTO GetExamination(int id)
        {
            var examination = _unitOfWork.Examinations.Get(id);
            return _mapper.Map<ExaminationDTO>(examination);
        }

        public IEnumerable<ExaminationDTO> GetExaminationsByPatient(int patientId)
        {
            var examinations = _unitOfWork.Examinations.Find(e => e.PatientId.Value == patientId).ToList();
            return _mapper.Map<IEnumerable<ExaminationDTO>>(examinations);
        }

        public IEnumerable<ExaminationDTO> GetExaminations()
        {
            var examinations = _unitOfWork.Examinations.GetAll().ToList();
            return _mapper.Map<IEnumerable<ExaminationDTO>>(examinations);
        }

        public void UpdateExamination(ExaminationDTO examinationDto)
        {
            var examination = _mapper.Map<Examination>(examinationDto);
            _unitOfWork.Examinations.Update(examination);
            _unitOfWork.Save();
        }
    }
}