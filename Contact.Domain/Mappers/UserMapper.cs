using System.Data;
using Contact.Domain.Entities;

namespace Contact.Domain.Mappers;

internal static class UserMapper
{
    internal static UserEntity ToPublicUser(this IDataRecord record) =>
        new UserEntity((int)record["Id"],
            (string)record["FirstName"],
            (string)record["LastName"],
            (string)record["Email"]
        );
}
