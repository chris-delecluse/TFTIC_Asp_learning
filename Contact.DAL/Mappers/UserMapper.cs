using System.Data;
using Contact.DAL.Entities;

namespace Contact.DAL.Mappers;

internal static class UserMapper
{
    internal static UserEntity ToUser(this IDataRecord record)
    {
        return new UserEntity
        {
            Id = (int)record["Id"],
            FirstName = (string)record["FirstName"],
            LastName = (string)record["LastName"],
            Email = (string)record["Email"],
        };
    }
}
