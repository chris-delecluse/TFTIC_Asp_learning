using Contact.DAL.Entities;

namespace Contact.DAL.Repositories;

public interface IAuthRepository
{
    public void Register(UserEntity user);
    public UserEntity? Login(string email, string password);
}
