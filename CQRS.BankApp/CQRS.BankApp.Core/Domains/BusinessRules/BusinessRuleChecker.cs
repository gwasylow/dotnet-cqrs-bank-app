using CQRS.BankApp.Core.Utils;
using System;

namespace CQRS.BankApp.Core.Domains.BusinessRules
{
    public static class BusinessRuleChecker
    {
        public static void Handle(params IBusinessRule[] businessRules)
        {
            foreach (var rule in businessRules)
            {
                if (!rule.IsValid())
                {
                    throw new BusinessRuleException(rule.ErrorMessage);
                }
            }
        }
    }
}
