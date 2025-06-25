using DesignPatterns.Repository;
using DesignPatterns_ASPNETCore.Models.ViewModels;

namespace DesignPatterns_ASPNETCore.Strategies
{
    public class ProductContext
    {
        private IProductStrategy _strategy;

        public IProductStrategy ProductStrategy 
        { 
            set 
            { 
                _strategy = value; 
            } 
        }

        public ProductContext(IProductStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(FormProductViewModel viewModel, IUnitOfWork unitOfWork)
        {
            // Ejecutar la estrategia 
            _strategy.Add(viewModel, unitOfWork);
        }
    }
}
