using CQRS.BankApp.Core.CQRS;

namespace CQRS.BankApp.Core.Domains.AccountDomain.Events
{
    public class MoneyTransferedEventHandler : IHandleEvent<MoneyTransferedEvent>
    {
        public void Handle(MoneyTransferedEvent @event)
        {

            //Notify
        }
    }
}
