using Contact.BLL.Entities;
using Contact.BLL.Mappers;
using Contact.BLL.Repositories;
using IDalContactRepository = Contact.DAL.Repositories.IContactRepository;
using DalContactEntity = Contact.DAL.Entities.ContactEntity;

namespace Contact.BLL.Services;

public class ContactService : IContactRepository
{
    private readonly IDalContactRepository _contactRepository;

    public ContactService(IDalContactRepository contactRepository) { _contactRepository = contactRepository; }

    public void Insert(ContactEntity contact) { _contactRepository.Insert(contact.ToDal()); }

    public IEnumerable<ContactEntity> Find() =>
        _contactRepository.Find()
            .ToBll();

    public void Remove(int id) { _contactRepository.Remove(id); }
}
