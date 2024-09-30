using CreditSuisse.TradesPortfolio.Domain.Entities;
using CreditSuisse.TradesPortfolio.Domain.Enums;
using CreditSuisse.TradesPortfolio.Domain.Interfaces;
using Category = CreditSuisse.TradesPortfolio.Domain.Entities.Category;

namespace CreditSuisse.TradesPortfolio.Domain.Services
{
    public class CategoryService : ICategory
    {
        IEnumerable<string> ICategory.GetByQuantityAndReferenceDate(int quantityOfRates, DateTime referenceDate)
        {
            List<string> tradeInfoValue = new List<string>();
            var tradeList = GetMockTrades(quantityOfRates);
            if (tradeList != null && tradeList.Count != 0)
            {
                foreach (var trade in tradeList)
                {
                    if (trade.NextPaymentDate < referenceDate.AddDays(30))
                    {
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {CreditSuisse.TradesPortfolio.Domain.Enums.Category.Expired}");
                    }
                    else if (trade.Value > 1000000 && trade.ClientSector == CreditSuisse.TradesPortfolio.Domain.Enums.ClientSector.Private.ToString())
                    {
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {CreditSuisse.TradesPortfolio.Domain.Enums.Category.HighRisk}");
                    }
                    else if (trade.Value > 1000000 && trade.ClientSector == CreditSuisse.TradesPortfolio.Domain.Enums.ClientSector.Public.ToString())
                    {
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {CreditSuisse.TradesPortfolio.Domain.Enums.Category.MediumRisk}");
                    }
                    else
                    {
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | Uncategorized");
                    }
                }
            }
            return tradeInfoValue;
        }

        private List<Trade> GetMockTrades(int quantityOfRates)
        {
            Random randomTradeValue = new Random();
            Random randomClientSector = new Random();
            var mockListOfTrades = new List<Trade>();
            for (int i = 0; i < quantityOfRates; i++)
            {
                var tradeValue = randomTradeValue.Next(100000, 10000000);
                Trade objTrade = new()
                {
                    Value = tradeValue,
                    ClientSector = tradeValue % 2 == 0 ? ClientSector.Private.ToString() : ClientSector.Public.ToString(),
                    NextPaymentDate = GetRandomPaymentDate()
                };

                mockListOfTrades.Add(objTrade);
            }
            return mockListOfTrades;
        }

        private DateTime GetRandomPaymentDate()
        {
            Random gen = new();
            DateTime start = new DateTime(2024, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
