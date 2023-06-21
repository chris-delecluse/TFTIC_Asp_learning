using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contact.App.Models.Auth;

public class LoginForm
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }

    [Required]
    [DisplayName("Password")]
    public string Password { get; set; }
}
