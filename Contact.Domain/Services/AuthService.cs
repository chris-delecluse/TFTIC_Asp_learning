using System.Data;
using Contact.Cqs.Shared;
using Contact.Domain.Commands;
using Contact.Domain.Entities;
using Contact.Domain.Mappers;
using Contact.Domain.Queries;
using Contact.Domain.Repositories;
using Contact.Tools.Database;

namespace Contact.Domain.Services;

public class AuthService : IAuthRepository
{
    private readonly IDbConnection _dbConnection;

    public AuthService(IDbConnection dbConnection) { _dbConnection = dbConnection; }

    public Result Execute(RegisterCommand command)
    {
        try
        {
            if (_dbConnection.State is not ConnectionState.Open)
                _dbConnection.Open();
            _dbConnection.ExecuteNonQuery("CSP_Register", true, command);
            _dbConnection.Close();
            return Result.Success();
        }
        catch (Exception e) { return Result.Failure(e.Message); }
    }

    public UserEntity? Execute(LoginQuery query)
    {
        if (_dbConnection.State is not ConnectionState.Open)
            _dbConnection.Open();
        UserEntity? user = _dbConnection.ExecuteReader("CSP_Login", record => record.ToPublicUser(), true, query)
            .FirstOrDefault();
        return user;
    }
}
