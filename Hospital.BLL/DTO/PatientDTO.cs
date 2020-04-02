using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class PatientDTO : PersonDTO
    {
        public int? EmployeeId { get; set; }
        public virtual EmployeeDTO Employee { get; set; }
        public virtual ICollection<ExaminationDTO> Examinations { get; set; }
    }
}