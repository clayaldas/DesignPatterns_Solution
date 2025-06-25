namespace DesignPatterns.StrategyPattern
{
  public class BicycleStrategy : IStrategy
  {
    public void Run()
    {
      Console.WriteLine("Voy en bicileta al aeropuerto.");
    }
  }
}
