using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {

        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$", ErrorMessage = "Password must be at least 6 characters long and include uppercase, lowercase, digit, and non-alphanumeric character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not match Password")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
