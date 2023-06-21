using Contact.BLL.Entities;
using DalUserEntity = Contact.DAL.Entities.UserEntity;

namespace Contact.BLL.Mappers;

internal static class UserMapper
{
    internal static DalUserEntity ToDal(this UserEntity userEntity)
    {
        DalUserEntity entity = new DAL.Entities.UserEntity
        {
            Id = userEntity.Id,
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Email = userEntity.Email,
            Password = userEntity.Password!
        };

        userEntity.Password = null;
        return entity;
    }

    internal static UserEntity ToBll(this DalUserEntity userEntity) => new (userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.Email);
}
