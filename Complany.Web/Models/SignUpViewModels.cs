using System.ComponentModel.DataAnnotations;

namespace Complany.Web.Models
{
    public class SignUpViewModels
    {
        [Required(ErrorMessage = "First Name is Required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public String Password { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password Does Not Match Password")]
        public String ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Required To Agree")]
        public bool IsAgree { get; set; }

    }
}
