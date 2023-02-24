namespace Bank.Application.CQRS.Interface
{
    public interface IQuery
    {
    }
    public interface IQuery<TQuery> where TQuery : IQuery<TQuery>
    {
    }
}