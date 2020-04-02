using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class ProcedureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }
        public string Notation { get; set; }
        public virtual ICollection<ExaminationDTO> Examinations { get; set; }
    }
}