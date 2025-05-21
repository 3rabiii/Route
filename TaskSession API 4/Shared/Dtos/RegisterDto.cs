using System.ComponentModel.DataAnnotations;

namespace Shared;

public class RegisterDto
{
    [Required(ErrorMessage = "Email is required")]
    public  string DisplayName { get; set; }
    [Required(ErrorMessage = "UserName is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    public string? PhoneNumber  { get; set; }
    
}