using System.Collections.Generic;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IDiagnosisService
    {
        void CreateDiagnosis(DiagnoseDTO diagnoseDto);
        void UpdateDiagnosis(DiagnoseDTO diagnoseDto);
        void DeleteDiagnosis(int diagnoseId);
        DiagnoseDTO GetDiagnosis(int diagnoseId);
        IEnumerable<DiagnoseDTO> GetDiagnoses();
        bool NameExists(string name);
    }
}