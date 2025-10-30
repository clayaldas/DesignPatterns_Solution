using Utilities.DesignPatterns.FactoryMethod_Profit.Products;

namespace Utilities.DesignPatterns.FactoryMethod_Profit.Factories;

public class LocalProfitFactory : ProfitFactory
{
    private readonly decimal _percentaje;

    public LocalProfitFactory(decimal percentage)
    {
     _percentaje = percentage;   
    }
    public override IProfit GetProfit()
    {
        return new LocalProfit(_percentaje);
    }
}
