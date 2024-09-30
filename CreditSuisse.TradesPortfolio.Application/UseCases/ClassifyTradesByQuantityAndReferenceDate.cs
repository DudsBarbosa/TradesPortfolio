using CreditSuisse.TradesPortfolio.Domain.Entities;
using CreditSuisse.TradesPortfolio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.TradesPortfolio.Application.UseCases
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
