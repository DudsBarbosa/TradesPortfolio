using CreditSuisse.TradesPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.TradesPortfolio.Domain.Interfaces
{
    public interface ITrade
    {
        public void Add(Trade trade);
        IEnumerable<Trade> GetAll(Trade trades);
    }
}
