using AutoMapper;
using Hospital.BLL.BusinessModels;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreatePatient(PatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            var userDto = _mapper.Map<UserDTO>(patient.User);

            User user = _unitOfWork.UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                _unitOfWork.Patients.Create(patient);
                _unitOfWork.Save();
            }
        }

        public void DeletePatient(int id)
        {
            _unitOfWork.Patients.Delete(id);
            _unitOfWork.Save();
        }

        public PatientDTO GetPatient(int id)
        {
            var patient = _unitOfWork.Patients.Get(id);
            return _mapper.Map<PatientDTO>(patient);
        }

        public IEnumerable<PatientDTO> GetPatients()
        {
            var patients = _unitOfWork.Patients.GetAll().ToList();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }

        public IEnumerable<PatientDTO> GetPatients(PatientSort patientSort)
        {
            var patients = GetPatients();
            switch (patientSort)
            {
                case PatientSort.AlphabetAscending:
                    return patients.OrderBy(p => p.UserName);
                case PatientSort.AlphabetDescending:
                    return patients.OrderByDescending(p => p.UserName);
                case PatientSort.BirthdayAscending:
                    return patients.OrderBy(p => p.Birthday);
                case PatientSort.BirthdayDescending:
                    return patients.OrderByDescending(p => p.Birthday);
                default: return patients;
            }
        }

        public IEnumerable<PatientDTO> GetPatientsByEmployee(int employeeId)
        {
            var patients = _unitOfWork.Patients.Find(p => p.EmployeeId == employeeId).ToList();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }

        public void UpdatePatient(PatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _unitOfWork.Patients.Update(patient);
            _unitOfWork.Save();
        }
    }
}