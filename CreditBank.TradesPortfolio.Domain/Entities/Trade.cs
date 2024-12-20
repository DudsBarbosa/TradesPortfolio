﻿namespace CreditBank.TradesPortfolio.Domain.Entities
{
    public class Trade
    {
        //indicates the transaction amount in dollars
        public double Value { get; set; }
        //indicates the client´s sector which can be "Public" or "Private"
        public string? ClientSector { get; set; }
        //indicates when the next payment from the client to the bank is expected
        public DateTime NextPaymentDate { get; set; }
        // Politically exposed person
        public bool IsPoliticallyExposed { get; set; }
    }
}
