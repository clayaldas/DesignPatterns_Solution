using DesignPatterns.Utilities.FactoryMethod_Profit.Products;

namespace DesignPatterns.Utilities.FactoryMethod_Profit.Factories
{
  public class ForeignProfitFactory : ProfitFactory
  {
    // Se requier los 2 datos miembro
    private readonly decimal _percentage;
    private readonly decimal _tax; //impuesto

    public ForeignProfitFactory(decimal percentage, decimal tax)
    {
      _percentage = percentage;
      _tax = tax;
    }

    public override IProfit GetProfit()
    {
      // Nuevo regla
      return new ForeignProfit(_percentage, _tax);
    }
  }
}
