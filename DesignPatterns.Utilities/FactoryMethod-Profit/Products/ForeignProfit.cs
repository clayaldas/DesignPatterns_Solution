namespace DesignPatterns.Utilities.FactoryMethod_Profit.Products
{
  public class ForeignProfit : IProfit
  {
    private readonly decimal _percentage;
    private readonly decimal _tax; //impuesto

    public ForeignProfit(decimal percentage, decimal tax)
    {
      _percentage = percentage;
      _tax = tax;
    }

    public decimal Profit(decimal amount)
    {
      // Implementamos el nuevo método.
      return (amount * _percentage) + _tax;
    }
  }
}
