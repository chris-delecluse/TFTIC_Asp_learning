using Contact.App.Attributes;
using Contact.App.Infrastructures.Sessions;
using Contact.App.Models.Auth;
using Contact.Cqs.Shared;
using Contact.Domain.Commands;
using Contact.Domain.Entities;
using Contact.Domain.Queries;
using Contact.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contact.App.Controllers;

public class AuthController : Controller
{
    private readonly IAuthRepository _userService;
    private readonly ISessionManager _sessionManager;

    public AuthController(IAuthRepository userService, ISessionManager sessionManager)
    {
        _userService = userService;
        _sessionManager = sessionManager;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(LoginForm form)
    {
        if (!ModelState.IsValid) return View(form);

        UserEntity? user = _userService.Execute(new LoginQuery(form.Email, form.Password));
        
        if (user is null)
        {
            ModelState.AddModelError("", "Invalid Credentials");
            return View(form);
        }

        _sessionManager.UserInfo = new UserInfo
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

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

    [CustomAuthorize]
    public IActionResult Logout()
    {
        _sessionManager.Clear();
        return RedirectToAction("index", "Home");
    }
}
