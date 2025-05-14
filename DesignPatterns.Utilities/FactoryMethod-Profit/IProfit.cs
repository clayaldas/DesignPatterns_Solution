namespace DesignPatterns.Utilities.FactoryMethod_Profit
{
    
    public interface IProfit
    {
        // Permite el cálculo de las ganancias de los productos
        // en las ventas LOCALES.
        // Todos los products que se creen con esta interface deben
        // implementar el el método (Profit).
        public decimal Profit(decimal amount);
    }
}
