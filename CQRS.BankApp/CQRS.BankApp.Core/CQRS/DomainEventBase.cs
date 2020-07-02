using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Core.CQRS
{
    public class DomainEventBase : IEvent
    {
        public DomainEventBase()
        {
            this.OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
