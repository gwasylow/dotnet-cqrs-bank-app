namespace CQRS.BankApp.Core.CQRS
{
    public interface IQueryBus
    {
        TResult Send<TQuery, TResult>(TQuery command) where TQuery : IQuery;
    }
}