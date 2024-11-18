using CreditBank.TradesPortfolio.Domain.Entities;

namespace CreditBank.TradesPortfolio.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = [];

        void ICategoryRepository.Add(Category category)
        {
            _categories.Add(category);
        }

        void ICategoryRepository.Delete(int id)
        {
            _categories.RemoveAll(c => c.CategoryId == id);
        }

        IEnumerable<Category> ICategoryRepository.GetAll()
        {
            return _categories;
        }

        Category ICategoryRepository.GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }

        void ICategoryRepository.Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
