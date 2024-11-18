using CreditBank.TradesPortfolio.Domain.Entities;

namespace CreditBank.TradesPortfolio.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);

        void Add(Category category);

        void Update(Category category);

        void Delete(int id);
    }
}
