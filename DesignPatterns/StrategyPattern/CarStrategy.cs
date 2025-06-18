namespace DesignPatterns.StrategyPattern
{
    public class CarStrategy : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Puede ir al aeropuerto en Auto");
        }
    }
}
