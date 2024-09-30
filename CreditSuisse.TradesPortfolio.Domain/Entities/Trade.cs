using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.TradesPortfolio.Domain.Entities
{
    public class Trade
    {
        //indicates the transaction amount in dollars
        public double Value { get; set; }
        //indicates the client´s sector which can be "Public" or "Private"
        public string? ClientSector { get; set; }
        //indicates when the next payment from the client to the bank is expected
        public DateTime NextPaymentDate { get; set; }
    }
}
