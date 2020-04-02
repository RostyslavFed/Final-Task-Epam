using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entity
{
    public class Examination
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Patient")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Diagnosis")]
        public int? DiagnoseId { get; set; }
        public virtual Diagnose Diagnose { get; set; }
        [Display(Name = "Date")] public DateTime Date { get; set; }
        [Display(Name = "Notation")] public string Notation { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}