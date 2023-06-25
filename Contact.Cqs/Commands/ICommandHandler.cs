using Contact.Cqs.Shared;

namespace Contact.Cqs.Commands;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Result Execute(TCommand command);
}
