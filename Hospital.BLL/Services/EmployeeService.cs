using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using AutoMapper;
using Hospital.BLL.BusinessModels;
using Hospital.BLL.DTO;
using Hospital.BLL.Infrastructure;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateEmployee(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var userDto = _mapper.Map<UserDTO>(employee.User);

            User user = _unitOfWork.UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = _mapper.Map<User>(userDto);

                var result = _unitOfWork.UserManager.Create(user, userDto.Password);

                // добавляем роль
                string employeeRole = "doctor";
                if (!_unitOfWork.RoleManager.RoleExists(employeeRole))
                {
                    _unitOfWork.RoleManager.Create(new Role(employeeRole));
                }
                _unitOfWork.UserManager.AddToRole(user.Id, employeeRole);

                // создаем рабочего
                employee.UserId = user.Id;
                employee.User = null;
                _unitOfWork.Staff.Create(employee);
                _unitOfWork.Save();
            }
        }

        public void UpdateEmployee(EmployeeDTO employeeDto)
        {
            //DeleteEmployee(employeeDto.Id);

            var employee = _mapper.Map<Employee>(employeeDto);

            var role = new IdentityUserRole()
            {
                RoleId = _unitOfWork.RoleManager.FindByName("doctor").Id,
                UserId = employee.UserId
            };
            employee.User.Roles.Add(role);

            var userDto = _mapper.Map<UserDTO>(employee.User);
            var user = _mapper.Map<User>(userDto);

            employee.UserId = user.Id;
            employee.User = null;

            try
            {
                _unitOfWork.UserManager.Update(user);
                user = _unitOfWork.UserManager.FindById(user.Id);

                employee.UserId = user.Id;
                employee.User = user;

                _unitOfWork.Staff.Update(employee);
                _unitOfWork.Save();
            }
            catch (DbEntityValidationException ex)
            {

            }
            catch (DbUpdateException ex)
            {

            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Staff.Get(id);
            _unitOfWork.Staff.Delete(id);
            _unitOfWork.UserManager.Delete(employee.User);
            _unitOfWork.Save();
        }

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = _unitOfWork.Staff.Get(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public IEnumerable<EmployeeDTO> GetStaff()
        {
            var staff = _unitOfWork.Staff.GetAll().ToList();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(staff);
        }

        public IEnumerable<EmployeeDTO> GetStaff(EmployeeSort employeeSort)
        {
            var employees = GetStaff();
            switch (employeeSort)
            {
                case EmployeeSort.AlphabetAscending:
                    return employees.OrderBy(e => e.UserName);
                case EmployeeSort.AlphabetDescending:
                    return employees.OrderByDescending(e => e.UserName);
                case EmployeeSort.CategoryAscending:
                    return employees.OrderBy(e => e.Category.Name);
                case EmployeeSort.CategoryDescending:
                    return employees.OrderByDescending(e => e.Category.Name);
                case EmployeeSort.PatientAscending:
                    return employees.OrderBy(e => e.Patients.Count);
                case EmployeeSort.PatientDescending:
                    return employees.OrderByDescending(e => e.Patients.Count);
                default: return employees;
            }
        }

        public IEnumerable<EmployeeDTO> GetStaffByCategory(int id)
        {
            var staff = _unitOfWork.Staff.GetAll().Where(e => e.CategoryId.Value == id);
            return _mapper.Map<IEnumerable<EmployeeDTO>>(staff);
        }
    }
}