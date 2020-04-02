using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Identity;
using Hospital.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Employee item)
        {
            _hospitalContext.Staff.Add(item);
        }

        public void Delete(int id)
        {
            var worker = _hospitalContext.Staff.Find(id);
            if (worker != null)
            {
                _hospitalContext.Staff.Remove(worker);
            }
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return _hospitalContext.Staff.Where(predicate).ToList();
        }

        public Employee Get(int id)
        {
            return _hospitalContext.Staff.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _hospitalContext.Staff;
        }

        public void Update(Employee item)
        {
            Employee employee = Get(item.Id);
            _mapper.Map(item, employee);
        }
    }
}