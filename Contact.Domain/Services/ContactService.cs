using System.Data;
using Contact.Cqs.Shared;
using Contact.Domain.Commands.Contact;
using Contact.Domain.Entities;
using Contact.Domain.Queries.Contact;
using Contact.Domain.Repositories;
using Contact.Tools.Database;

namespace Contact.Domain.Services;

public class ContactService : IContactRepository
{
    private readonly IDbConnection _dbConnection;

    public ContactService(IDbConnection dbConnection) { _dbConnection = dbConnection; }

    public Result Execute(ContactCommand command)
    {
        try
        {
            if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();
            _dbConnection.ExecuteNonQuery(
                "insert into contact (firstname, lastname, email, birthDate, phoneNumber) values (@firstname, @lastname, @email, @birthDate, @phoneNumber)",
                false,
                new { command.FirstName, command.LastName, command.Email, command.BirthDate, command.PhoneNumber }
            );
            return Result.Success();
        }
        catch (Exception e) { return Result.Failure(e.Message); }
    }

    public IEnumerable<ContactEntity> Execute(GetAllContactQuery query)
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

    public Result Execute(RemoveContactCommand command)
    {
        try
        {
            if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("delete from contact where id = @id", parameters: new { command.Id });
            return Result.Success();
        }
        catch (Exception e) { return Result.Failure(e.Message); }
    }
}
