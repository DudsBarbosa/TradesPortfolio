using CreditBank.TradesPortfolio.Domain.Entities;
using CreditBank.TradesPortfolio.Domain.Enums;
using CreditBank.TradesPortfolio.Domain.Interfaces;
using Category = CreditBank.TradesPortfolio.Domain.Entities.Category;

namespace CreditBank.TradesPortfolio.Domain.Services
{
    public class CategoryService : ICategory
    {
        IEnumerable<string> ICategory.GetByQuantityAndReferenceDate(int quantityOfRates, DateTime referenceDate)
        {
            List<string> tradeInfoValue = [];
            var tradeList = GetMockTrades(quantityOfRates);
            if (tradeList != null && tradeList.Count != 0)
            {
                Category category = new();
                foreach (var trade in tradeList)
                {
                    var totalDaysNextPayment = trade.NextPaymentDate.Subtract(referenceDate).TotalDays;
                    if (totalDaysNextPayment > 30)
                    {
                        category.Description = Enums.Category.Expired.ToString();
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {category.Description}");
                    }
                    else if (trade.Value > 1000000 && trade.ClientSector == ClientSector.Private.ToString() && !trade.IsPoliticallyExposed)
                    {
                        category.Description = Enums.Category.HighRisk.ToString();
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {category.Description}");
                    }
                    else if (trade.Value > 1000000 && trade.ClientSector == ClientSector.Public.ToString() && !trade.IsPoliticallyExposed)
                    {
                        category.Description = Enums.Category.MediumRisk.ToString();
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {category.Description}");
                    }
                    else if (trade.Value > 5000000 && trade.ClientSector == ClientSector.Public.ToString() && trade.IsPoliticallyExposed)
                    {
                        category.Description = Enums.Category.Pep.ToString();
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {category.Description}");
                    }
                    else
                    {
                        category.Description = Enums.Category.Uncategorized.ToString();
                        tradeInfoValue.Add($"{trade.Value} {trade.ClientSector} {trade.NextPaymentDate:MM/dd/yyyy} | {category.Description}");
                    }
                }
            }
            return tradeInfoValue;
        }

        private List<Trade> GetMockTrades(int quantityOfRates)
        {
            Random randomTradeValue = new();
            Random randomClientSector = new();
            var mockListOfTrades = new List<Trade>();
            for (int i = 0; i < quantityOfRates; i++)
            {
                var tradeValue = randomTradeValue.Next(100000, 10000000);
                Trade objTrade = new()
                {
                    Value = tradeValue,
                    ClientSector = tradeValue % 2 == 0 ? ClientSector.Private.ToString() : ClientSector.Public.ToString(),
                    NextPaymentDate = GetRandomPaymentDate(),
                    IsPoliticallyExposed = tradeValue % 2 != 0 && tradeValue > 5000000
                };

                mockListOfTrades.Add(objTrade);
            }
            return mockListOfTrades;
        }

        private DateTime GetRandomPaymentDate()
        {
            Random gen = new();
            DateTime start = new(2024, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
