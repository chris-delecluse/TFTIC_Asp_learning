namespace Contact.App.Infrastructures.Sessions;

public interface ISessionManager
{
    UserInfo? UserInfo { get; set; }
    void Clear();
}
