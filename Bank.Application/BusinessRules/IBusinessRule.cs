namespace Bank.Application.BusinessRules
{
    public interface IBusinessRule
    {
        bool IsValid();

        string ErrorMessage { get; }
    }
}
