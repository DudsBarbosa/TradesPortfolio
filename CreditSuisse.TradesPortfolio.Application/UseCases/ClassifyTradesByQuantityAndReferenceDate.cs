using CreditBank.TradesPortfolio.Domain.Interfaces;

namespace CreditBank.TradesPortfolio.Application.UseCases
{
    public class ClassifyTradesByQuantityAndReferenceDate
    {
        private readonly ICategory _category;

        public ClassifyTradesByQuantityAndReferenceDate(ICategory category)
        {
            _category = category;
        }

        public IList<string> GetCategory(DateTime referenceDate, int quantityOfRates)
        {
            return _category.GetByQuantityAndReferenceDate(quantityOfRates, referenceDate).ToList();
        }
    }
}
