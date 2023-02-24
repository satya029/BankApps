namespace Bank.Application.CQRS.Interface
{
    public interface ICommandsBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
