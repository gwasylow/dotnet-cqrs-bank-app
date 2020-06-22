namespace CQRS.BankApp.Core.CQRS
{
    public interface IQuery
    {
    }
    public interface IQuery<TQuery> where TQuery : IQuery<TQuery>
    {
    }
}