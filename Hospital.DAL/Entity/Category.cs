using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entity
{
    public class Category
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [MinLength(3, ErrorMessage = "Min length 2 characters")]
        [MaxLength(20, ErrorMessage = "Max length 20 characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public virtual ICollection<Employee> Workers { get; set; }
    }
}