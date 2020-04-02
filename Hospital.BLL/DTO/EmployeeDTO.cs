using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class EmployeeDTO : PersonDTO
    {
        public int? CategoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual ICollection<PatientDTO> Patients { get; set; }
    }
}