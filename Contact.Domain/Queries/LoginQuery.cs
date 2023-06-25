using Contact.Cqs.Queries;
using Contact.Domain.Entities;

namespace Contact.Domain.Queries;

public class LoginQuery : IQuery<UserEntity?>
{
    public string Email { get; init; }
    public string Password { get; init; }

    public LoginQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
