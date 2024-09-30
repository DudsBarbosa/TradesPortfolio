
using CreditSuisse.TradesPortfolio.Application.UseCases;
using CreditSuisse.TradesPortfolio.Domain.Services;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Credit Suisse trades portfolio application.\n");

        // Input reference date
        Console.WriteLine("Please, input reference date in mm/dd/yyyy format.");
        string? inputReferenceDate = Console.ReadLine();
        string format = "MM/dd/yyyy";
        DateTime referenceDate;
        if (string.IsNullOrWhiteSpace(inputReferenceDate) || !DateTime.TryParseExact(inputReferenceDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out referenceDate))
        {
            Console.WriteLine("Please, input reference date in mm/dd/yyyy format.");
            return;
        }

        // Input quantity of rates
        Console.WriteLine("Please, input the quantity of rates to return.");
        string? inputQuantityOfRates = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputQuantityOfRates) || !int.TryParse(inputQuantityOfRates, out int quantityOfRates))
        {
            Console.WriteLine("Please, input the quantity of rates to return.\n");
            return;
        }

        Console.WriteLine("\n");
        OutputCategories(referenceDate, quantityOfRates);
    }

    private static void OutputCategories(DateTime referenceDate, int quantityOfRates)
    {
        var categoryService = new CategoryService();
        var classifiedTrades = new ClassifyTradesByQuantityAndReferenceDate(categoryService);
        var tradesResult = classifiedTrades.GetCategory(referenceDate, quantityOfRates);

        Console.WriteLine("------------- Output:\n");
        foreach (var trade in tradesResult)
        {
            Console.WriteLine($"{trade}");
        }
    }
}