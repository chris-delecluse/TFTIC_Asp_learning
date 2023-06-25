using Contact.Cqs.Commands;
using Contact.Cqs.Queries;
using Contact.Domain.Commands.Contact;
using Contact.Domain.Entities;
using Contact.Domain.Queries.Contact;

namespace Contact.Domain.Repositories;

public interface IContactRepository : ICommandHandler<ContactCommand>,
    ICommandHandler<RemoveContactCommand>,
    IQueryHandler<GetAllContactQuery, IEnumerable<ContactEntity>> { }
