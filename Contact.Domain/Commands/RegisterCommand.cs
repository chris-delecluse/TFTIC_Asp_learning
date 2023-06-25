using Contact.Cqs.Commands;

namespace Contact.Domain.Commands;

public class RegisterCommand : ICommand
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }

    public RegisterCommand(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}
