namespace DesignPatterns.Utilities.FactoryMethod_Profit.Products
{
    public class ForeignProfit : IProfit
    {
        private readonly decimal _percentage;
        private readonly decimal _tax; // Impuesto

        public ForeignProfit(decimal percentage, decimal tax)
        {
            _percentage = percentage;
            _tax = tax;
        }

        public decimal Profit(decimal amount)
        {
            // Implementación de la nueva regla de negocios para obtener
            // las ganancias en ventas de productos con venta en el extranjero.
            return (amount * _percentage) + _tax;
        }
    }
}
