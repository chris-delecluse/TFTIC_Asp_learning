using Contact.Cqs.Commands;

namespace Contact.Domain.Commands.Contact;

public class ContactCommand: ICommand
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime BirthDate { get; init; }
    public string PhoneNumber { get; init; }

    public ContactCommand(string firstName, string lastName, string email, DateTime birthDate, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }
}
