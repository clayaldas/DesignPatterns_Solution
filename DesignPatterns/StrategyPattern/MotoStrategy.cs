namespace DesignPatterns.StrategyPattern
{
  public class MotoStrategy : IStrategy
  {
    public void Run()
    {
      Console.WriteLine("Voy en moto al aeropuerto.");
    }
  }
}
