using Bank.Application.Utils;

namespace Bank.Application.BusinessRules
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
