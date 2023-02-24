namespace Bank.Application.CQRS.Interface
{
    public interface IQueryBus
    {
        TResult Send<TQuery, TResult>(TQuery command) where TQuery : IQuery;
    }
}