using Utilities.DesignPatterns.FactoryMethod_Profit.Products;

namespace Utilities.DesignPatterns.FactoryMethod_Profit.Factories;

public class ForeignProfitFactory : ProfitFactory
{
    private readonly decimal _percentage;
    private readonly decimal _tax;

    public ForeignProfitFactory(decimal percentage, decimal tax)
    {
        _percentage = percentage;
        _tax = tax;
    }
    public override IProfit GetProfit()
    {
        return new ForeignProfit(_percentage, _tax);
    }
}
