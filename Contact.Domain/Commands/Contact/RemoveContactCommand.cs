using Contact.Cqs.Commands;

namespace Contact.Domain.Commands.Contact;

public class RemoveContactCommand : ICommand
{
    public int Id { get; init; }

    public RemoveContactCommand(int id)
    {
        Id = id;
    }
}
