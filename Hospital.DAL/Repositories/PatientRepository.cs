using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Identity;
using Hospital.DAL.Interfaces;
using Microsoft.AspNet.Identity;

namespace Hospital.DAL.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public PatientRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Patient item)
        {
            var user = item.User;
            var userManager = new UserManager(_hospitalContext);
            var result = userManager.Create(user, user.PasswordHash);
            if (result.Succeeded)
            {
                // добавляем роль
                var roleManager = new RoleManager(_hospitalContext);
                string patientRole = "patient";

                if (!roleManager.RoleExists(patientRole))
                {
                    roleManager.Create(new Role(patientRole));
                }

                userManager.AddToRole(user.Id, patientRole);
                _hospitalContext.Patients.Add(item);
            }
        }

        public void Delete(int id)
        {
            var patient = _hospitalContext.Patients.Find(id);
            if (patient != null)
            {
                _hospitalContext.Patients.Remove(patient);
            }
        }

        public IEnumerable<Patient> Find(Func<Patient, bool> predicate)
        {
            return _hospitalContext.Patients.Where(predicate).ToList();
        }

        public Patient Get(int id)
        {
            return _hospitalContext.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _hospitalContext.Patients;
        }

        public void Update(Patient item)
        {
            Patient patient = Get(item.Id);
            _mapper.Map(item, patient);
        }
    }
}