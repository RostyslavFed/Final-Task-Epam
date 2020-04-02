using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entity
{
	public class User : IdentityUser
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Field must be set")]
        [MinLength(6, ErrorMessage = "Min length 6 characters"),
            MaxLength(20, ErrorMessage = "Max length 20 characters")]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
