using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.BankApp.Core.Utils
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException()
        {
        }

        public BusinessRuleException(string message) : base(message)
        {
        }
    }
}
