using Category = CreditSuisse.TradesPortfolio.Domain.Entities.Category;

namespace CreditSuisse.TradesPortfolio.Domain.Interfaces
{
    public interface ICategory
    {
        IEnumerable<string> GetByQuantityAndReferenceDate(int quantityOfRates, DateTime referenceDate);
    }
}
