using System.Collections.Generic;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IExaminationService
    {
        void CreateExamination(ExaminationDTO examinationDto);
        void UpdateExamination(ExaminationDTO examinationDto);
        void DeletExamination(int id);
        ExaminationDTO GetExamination(int id);
        IEnumerable<ExaminationDTO> GetExaminations();
        IEnumerable<ExaminationDTO> GetExaminationsByPatient(int patientId);
    }
}