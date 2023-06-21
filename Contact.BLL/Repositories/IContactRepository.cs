using Contact.BLL.Entities;

namespace Contact.BLL.Repositories;

public interface IContactRepository
{
    void Insert(ContactEntity contact);
    IEnumerable<ContactEntity>? Find();
    void Remove(int id);
}
