using CQRS.BankApp.Core.CQRS;
using System;

namespace CQRS.BankApp.Core.Domains.UserDomain.Events
{
    public class UserLogoutEventHandler : IHandleEvent<UserLogoutEvent>
    {
        public void Handle(UserLogoutEvent @event)
        {

        }
    }
}
