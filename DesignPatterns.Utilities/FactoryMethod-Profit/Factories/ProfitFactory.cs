namespace DesignPatterns.Utilities.FactoryMethod_Profit.Factories
{
    public abstract class ProfitFactory
    {
        // Factory Method: esta es la regla que define el contrato 
        //                 para las subclases (fábricas).
        public abstract IProfit GetProfit();
    }
}
