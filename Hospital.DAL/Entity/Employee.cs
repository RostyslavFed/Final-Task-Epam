using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entity
{
    public class Employee
    {
        [Key] public int Id { get; set; }
        [Required]public string UserId { get; set; }
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}