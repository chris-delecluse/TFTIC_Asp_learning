using Contact.App.Models.Auth;
using Contact.BLL.Entities;

namespace Contact.App.Mappers;

internal static class UserMapper
{
    internal static UserEntity ToBll(this RegisterForm form) =>
        new (form.FirstName, form.LastName, form.Email, form.Password);
}
