using CreditSuisse.TradesPortfolio.Domain.Entities;
using Category = CreditSuisse.TradesPortfolio.Domain.Entities.Category;

namespace CreditSuisse.TradesPortfolio.Domain.Interfaces
{
    public interface ICategory
    {
        IEnumerable<string> GetByQuantityAndReferenceDate(int quantityOfRates, DateTime referenceDate);

        Category GetCategory(int id);

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
