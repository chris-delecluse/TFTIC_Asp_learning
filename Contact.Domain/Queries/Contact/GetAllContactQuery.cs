using Contact.Cqs.Queries;
using Contact.Domain.Entities;

namespace Contact.Domain.Queries.Contact;

public class GetAllContactQuery : IQuery<IEnumerable<ContactEntity>> { }
