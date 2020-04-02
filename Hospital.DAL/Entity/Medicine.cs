using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entity
{
    public class Medicine
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [MinLength(3, ErrorMessage = "Min length 3 characters")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [MinLength(3, ErrorMessage = "Min length 3 characters")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        [Display(Name = "Medication Form")]
        public string MedicationForm { get; set; }

        [Display(Name = "Use")] public string Use { get; set; }
        [Display(Name = "Schedule")] public string Schedule { get; set; }
        [Display(Name = "Notation")] public string Notation { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
    }
}