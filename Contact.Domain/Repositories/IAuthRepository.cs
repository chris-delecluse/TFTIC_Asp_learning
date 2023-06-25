using Contact.Cqs.Commands;
using Contact.Cqs.Queries;
using Contact.Domain.Commands;
using Contact.Domain.Entities;
using Contact.Domain.Queries;

namespace Contact.Domain.Repositories;

public interface IAuthRepository : ICommandHandler<RegisterCommand>, IQueryHandler<LoginQuery, UserEntity?> { }
