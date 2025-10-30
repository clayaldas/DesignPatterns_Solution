namespace Utilities.DesignPatterns.FactoryMethod_Profit.Products;

public class LocalProfit : IProfit
{
    private readonly decimal _percentage;

    public LocalProfit(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal Profit(decimal amount)
    {
        return amount * _percentage;
    }
}
