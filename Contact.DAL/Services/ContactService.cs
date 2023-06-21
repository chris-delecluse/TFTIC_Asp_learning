using System.Data;
using Contact.DAL.Entities;
using Contact.DAL.Repositories;
using Contact.Tools.Database;

namespace Contact.DAL.Services;

public class ContactService : IContactRepository
{
    private readonly IDbConnection _dbConnection;

    public ContactService(IDbConnection dbConnection) { _dbConnection = dbConnection; }

    public void Insert(ContactEntity contact)
    {
        if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();

        _dbConnection.ExecuteNonQuery(
            "insert into contact (firstname, lastname, email, birthDate, phoneNumber) values (@firstname, @lastname, @email, @birthDate, @phoneNumber)",
            false,
            new { contact.LastName, contact.FirstName, contact.Email, contact.BirthDate, contact.PhoneNumber }
        );
    }

    public IEnumerable<ContactEntity> Find()
    {
        if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();

        IEnumerable<ContactEntity> contacts = _dbConnection.ExecuteReader<ContactEntity>("select * from contact",
            record => new ContactEntity
            {
                Id = (int)record["id"],
                FirstName = (string)record["firstname"],
                LastName = (string)record["lastname"],
                Email = (string)record["email"],
                BirthDate = (DateTime)record["birthDate"],
                PhoneNumber = (string)record["phoneNumber"]
            }
        );

        return contacts;
    }

    public void Remove(int id)
    {
        if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();

        _dbConnection.ExecuteNonQuery("delete from contact where id = @id", parameters: new { id });
    }
}
