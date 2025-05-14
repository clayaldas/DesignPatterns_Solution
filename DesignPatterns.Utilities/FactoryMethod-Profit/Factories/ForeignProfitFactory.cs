using DesignPatterns.Utilities.FactoryMethod_Profit.Products;

namespace DesignPatterns.Utilities.FactoryMethod_Profit.Factories
{
    public class ForeignProfitFactory : ProfitFactory
    {
        private readonly decimal _percentage;
        private readonly decimal _tax; // Impuesto

        public ForeignProfitFactory(decimal percentage, decimal tax)
        {
            _percentage = percentage;
            _tax = tax;
        }
        public override IProfit GetProfit()
        {
            return new ForeignProfit(_percentage, _tax);
        }
    }
}
