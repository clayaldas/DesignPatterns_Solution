using DesignPatterns.Utilities.FactoryMethod_Profit.Products;

namespace DesignPatterns.Utilities.FactoryMethod_Profit.Factories
{
    public class LocalProfitFactory : ProfitFactory
    {
        private readonly decimal _percentage;

        public LocalProfitFactory(decimal percentage)
        {
            _percentage = percentage;
        }

        public override IProfit GetProfit()
        {
            return new LocalProfit(_percentage);
        }
    }
}
