using System.ComponentModel.DataAnnotations;

namespace Hospital.WEB.Models.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")] public bool RememberMe { get; set; }
    }
}