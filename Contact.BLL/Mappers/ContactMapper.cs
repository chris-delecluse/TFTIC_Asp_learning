using Contact.BLL.Entities;
using DalContactEntity = Contact.DAL.Entities.ContactEntity;

namespace Contact.BLL.Mappers;

internal static class ContactMapper
{
    internal static DalContactEntity ToDal(this ContactEntity contact) =>
        new()
        {
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            BirthDate = contact.BirthDate,
            PhoneNumber = contact.PhoneNumber
        };

    internal static ContactEntity ToBll(this DalContactEntity contact) =>
        new(contact.Id, contact.FirstName, contact.LastName, contact.Email, contact.BirthDate, contact.PhoneNumber);

    internal static IEnumerable<ContactEntity> ToBll(this IEnumerable<DalContactEntity> entities)
    {
        List<ContactEntity> contacts = new List<ContactEntity>();

        foreach (DalContactEntity entity in entities)
        {
            contacts.Add(new ContactEntity(entity.Id,
                    entity.FirstName,
                    entity.LastName,
                    entity.Email,
                    entity.BirthDate,
                    entity.PhoneNumber
                )
            );
        }

        return contacts;
    }
}