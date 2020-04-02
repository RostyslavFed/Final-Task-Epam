using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entity
{
    public class Patient
    {
        [Key] public int Id { get; set; }
        public virtual User User { get; set; }
        
        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
    }
}