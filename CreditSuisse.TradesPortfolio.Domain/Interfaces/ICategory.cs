namespace CreditBank.TradesPortfolio.Domain.Interfaces
{
    public interface ICategory
    {
        IEnumerable<string> GetByQuantityAndReferenceDate(int quantityOfRates, DateTime referenceDate);
    }
}
