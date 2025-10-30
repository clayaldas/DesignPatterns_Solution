namespace Utilities.DesignPatterns.FactoryMethod_Profit;

// Todos los productos que se creen con esta interfaz deben implementar
// el metodo Profit
public interface IProfit
{
    // Permite realizar el cálculo de la ganancia en producto
    decimal Profit(decimal amount);
}
