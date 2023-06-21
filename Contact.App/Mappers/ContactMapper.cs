using Contact.App.Models.Contact;
using Contact.BLL.Entities;

namespace Contact.App.Mappers;

internal static class ContactMapper
{
    internal static ContactEntity ToBll(this ContactViewModel model) =>
        new (model.FirstName, model.LastName, model.Email, model.BirthDate, model.PhoneNumber);
}
