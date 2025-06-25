namespace DesignPatterns.Utilities.FactoryMethod_Profit
{
  // Todos productos que se cree con esta interfaz deben implementar el método Profit.
  public interface IProfit
  {
    // Permite el cálculo de la ganancia de un producto
    public decimal Profit(decimal amount);

  }
}
