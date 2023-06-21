using Contact.BLL.Entities;

namespace Contact.BLL.Repositories;

public interface IAuthRepository
{
    public void Register(UserEntity user);
    public UserEntity? Login(string email, string password);
}
