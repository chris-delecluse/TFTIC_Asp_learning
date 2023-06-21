using Contact.DAL.Entities;

namespace Contact.DAL.Repositories;

public interface IContactRepository
{
    void Insert(ContactEntity contact);
    IEnumerable<ContactEntity> Find();
    void Remove(int id);
}
