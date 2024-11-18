using CreditBank.TradesPortfolio.Domain.Entities;

namespace CreditBank.TradesPortfolio.Domain.Interfaces
{
    public interface ITrade
    {
        IEnumerable<Trade> GetAll(Trade trades);
    }
}
