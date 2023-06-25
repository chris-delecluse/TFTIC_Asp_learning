using Contact.App.Models.Auth;
using Contact.Cqs.Shared;
using Contact.Domain.Commands;
using Contact.Domain.Queries;
using Contact.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        if (_userService.Execute(new LoginQuery(form.Email, form.Password)) is null)
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

        Result result =
            _userService.Execute(new RegisterCommand(form.FirstName, form.LastName, form.Email, form.Password));

        if (result.IsFailure)
        {
            ModelState.AddModelError("", "Email address already used");
            return View(form);
        }

        return RedirectToAction("Login", "Auth");
    }
}
