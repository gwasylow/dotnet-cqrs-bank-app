using System;

namespace CQRS.BankApp.Core.CQRS
{
    public interface IEvent
    {
        DateTime OccurredOn { get; }
    }
}
