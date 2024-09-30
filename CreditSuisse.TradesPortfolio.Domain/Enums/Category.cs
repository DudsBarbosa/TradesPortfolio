namespace CreditSuisse.TradesPortfolio.Domain.Enums
{
    public enum Category
    {
        // Trades whose next payment date is late by more than 30 days based on a reference date which will be given.
        Expired,
        // Trades with value greater than 1,000,000 and client from Private Sector.
        HighRisk,
        // Trades with value greater than 1,000,000 and client from Public Sector.
        MediumRisk,
        // Trades not categorized.
        Uncategorized,
        // Politically exposed person
        Pep
    }
}
