using System.Data;
using Contact.DAL.Entities;
using Contact.DAL.Mappers;
using Contact.DAL.Repositories;
using Contact.Tools.Database;

namespace Contact.DAL.Services;

public class AuthService : IAuthRepository
{
    private readonly IDbConnection _dbConnection;

    public AuthService(IDbConnection dbConnection) { _dbConnection = dbConnection; }

    public UserEntity? Login(string email, string password)
    {
        if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();

        return _dbConnection.ExecuteReader("CSP_Login", dr => dr.ToUser(), true, new { email, password })
            .SingleOrDefault();
    }

    public void Register(UserEntity user)
    {
        if (_dbConnection.State is not ConnectionState.Open) _dbConnection.Open();

        _dbConnection.ExecuteNonQuery("CSP_Register",
            true,
            new { user.FirstName, user.LastName, user.Email, user.Password }
        );
    }
}
