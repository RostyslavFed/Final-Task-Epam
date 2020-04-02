using System.Collections.Generic;
using Hospital.BLL.BusinessModels;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IEmployeeService
    {
        void CreateEmployee(EmployeeDTO employeeDto);
        void UpdateEmployee(EmployeeDTO employeeDto);
        void DeleteEmployee(int id);
        EmployeeDTO GetEmployee(int id);
        IEnumerable<EmployeeDTO> GetStaff();
        IEnumerable<EmployeeDTO> GetStaff(EmployeeSort employeeSort);
        IEnumerable<EmployeeDTO> GetStaffByCategory(int id);
    }
}