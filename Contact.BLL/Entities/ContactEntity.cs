namespace Contact.BLL.Entities;

public class ContactEntity
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public DateTime BirthDate { get; init; }
    public string PhoneNumber { get; init; }

    public ContactEntity(string firstName, string lastName, string email, DateTime birthDate, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }
    
    internal ContactEntity(int id, string firstName, string lastName, string email, DateTime birthDate, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
    }
}
