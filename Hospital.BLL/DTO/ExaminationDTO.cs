using System;
using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class ExaminationDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public virtual PatientDTO Patient { get; set; }
        public int? DiagnoseId { get; set; }
        public virtual DiagnoseDTO Diagnose { get; set; }
        public DateTime Date { get; set; }
        public string Notation { get; set; }
        public virtual ICollection<OperationDTO> Operations { get; set; }
        public virtual ICollection<MedicineDTO> Medicines { get; set; }
        public virtual ICollection<ProcedureDTO> Procedures { get; set; }
    }
}