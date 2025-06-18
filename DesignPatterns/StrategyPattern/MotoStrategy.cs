namespace DesignPatterns.StrategyPattern
{
    public class MotoStrategy : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Puede ir al aeropuerto en Moto");
        }
    }
}
