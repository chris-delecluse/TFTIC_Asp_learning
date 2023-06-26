namespace Contact.App.Infrastructures.Sessions;

public class UserInfo
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName
    {
        get => $"{FirstName} {LastName}";
    }
}
