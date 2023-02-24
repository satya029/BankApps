namespace Bank.Application.Utils
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
