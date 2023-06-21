using Contact.App.Mappers;
using Contact.App.Models.Auth;
using Contact.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Contact.App.Controllers;

public class AuthController : Controller
{
    private readonly IAuthRepository _userService;

    public AuthController(IAuthRepository userService) => _userService = userService;

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(LoginForm form)
    {
        if (!ModelState.IsValid) return View(form);
        
        if ( _userService.Login(form.Email, form.Password) is null)
        {
            ModelState.AddModelError("", "Invalid Credentials");
            return View(form);
        }

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(RegisterForm form)
    {
        if (!ModelState.IsValid) return View(form);

        try
        {
            _userService.Register(form.ToBll());
            return RedirectToAction("Login", "Auth");
        }
        catch (SqlException e)
        {
            ModelState.AddModelError("", "Email address already used");
            return View(form);
        }
    }
}
