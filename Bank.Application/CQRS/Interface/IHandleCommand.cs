namespace Bank.Application.CQRS.Interface
{
    public interface IHandleCommand
    {

    }
    public interface IHandleCommand<TCommand> : IHandleCommand
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
