using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatterns_ASPNETCore.Models.ViewModels;

namespace DesignPatterns_ASPNETCore.Strategies
{
    public class ProductWithCategoryStrategy : IProductStrategy
    {
        public void Add(FormProductViewModel viewModel, IUnitOfWork unitOfWork)
        {
            // Crear el producto
            var product = new Product();
            product.Name = viewModel.Name;
            product.UnitsInStock = viewModel.UnitsInStock;
            product.UnitPrice = viewModel.UnitPrice;

            //  Si se ha seleccionado una categoria, asignar el "CategoryId" al campo
            //  de la clase "Product" que es de tipo "Guid".
            product.CategoryId = (Guid)viewModel.CategoryId;

            // Utilizar el patron Unit Of Work para agregar el producto
            unitOfWork.Products.Add(product);

            // Enviar los cambios a la Base de Datos.
            unitOfWork.Save();
        }
    }
}
