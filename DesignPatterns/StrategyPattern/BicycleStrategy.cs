namespace DesignPatterns.StrategyPattern
{
    public class BicycleStrategy : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Puede ir al aeropuerto en bicicleta");
        }
    }
}
