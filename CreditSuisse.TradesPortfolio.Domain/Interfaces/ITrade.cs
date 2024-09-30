using CreditSuisse.TradesPortfolio.Domain.Entities;

namespace CreditSuisse.TradesPortfolio.Domain.Interfaces
{
    public interface ITrade
    {
        IEnumerable<Trade> GetAll(Trade trades);
    }
}
