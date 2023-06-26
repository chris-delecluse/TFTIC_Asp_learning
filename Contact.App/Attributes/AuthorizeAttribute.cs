using Contact.App.Infrastructures.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Contact.App.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
class CustomAuthorizeAttribute : TypeFilterAttribute
{
    public CustomAuthorizeAttribute() : base(typeof(CustomAuthorizeFilter)) { }
}

class CustomAuthorizeFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        ISessionManager? sessionManager = context.HttpContext.RequestServices.GetService<ISessionManager>();

        if (sessionManager is not null)
        {
            if (sessionManager.UserInfo is null) context.Result =
                new RedirectToActionResult("Login", "Auth", null);
        }
        else { context.Result = new ForbidResult(); }
    }
}
