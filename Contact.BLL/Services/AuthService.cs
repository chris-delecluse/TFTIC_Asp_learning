using Contact.BLL.Entities;
using Contact.BLL.Mappers;
using Contact.BLL.Repositories;
using IDalAuthRepository = Contact.DAL.Repositories.IAuthRepository;

namespace Contact.BLL.Services;

public class AuthService: IAuthRepository
{
    private readonly IDalAuthRepository _authRepository;

    public AuthService(IDalAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public void Register(UserEntity user)
    {
        _authRepository.Register(user.ToDal());
    }

    public UserEntity? Login(string email, string password)
    {
        return _authRepository.Login(email, password)?.ToBll();
    }
}
