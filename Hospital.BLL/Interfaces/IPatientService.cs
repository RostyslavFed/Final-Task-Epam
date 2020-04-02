using System.Collections.Generic;
using Hospital.BLL.BusinessModels;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IPatientService
    {
        void CreatePatient(PatientDTO patientDto);
        void UpdatePatient(PatientDTO patientDto);
        void DeletePatient(int id);
        PatientDTO GetPatient(int id);
        IEnumerable<PatientDTO> GetPatients();
        IEnumerable<PatientDTO> GetPatients(PatientSort patientSort);
        IEnumerable<PatientDTO> GetPatientsByEmployee(int employeeId);
    }
}