namespace CQRS.BankApp.Core.Domains.BusinessRules
{
    public interface IBusinessRule
    {
        bool IsValid();

        string ErrorMessage { get; }
    }
}
