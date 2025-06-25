namespace DesignPatterns.StrategyPattern
{
  public class CarStrategy : IStrategy
  {
    public void Run()
    {
      Console.WriteLine("Voy en auto al aeropuerto.");
    }
  }
}
