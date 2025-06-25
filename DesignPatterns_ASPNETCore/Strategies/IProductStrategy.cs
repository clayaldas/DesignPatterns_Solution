using DesignPatterns.Repository;
using DesignPatterns_ASPNETCore.Models.ViewModels;

namespace DesignPatterns_ASPNETCore.Strategies
{
    public interface IProductStrategy
    {
        public void Add(FormProductViewModel viewModel, IUnitOfWork unitOfWork);
    }
}
