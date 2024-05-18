using System.ComponentModel.DataAnnotations;

namespace ParcialUnoP_IV.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Contraseña incorrecta")]
        public string ConfirmPassword { get; set; }
    }
}
