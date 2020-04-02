using System;
using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string InstructionForPreparation { get; set; }
        public string Notation { get; set; }
        public virtual ICollection<ExaminationDTO> Examinations { get; set; }
    }
}