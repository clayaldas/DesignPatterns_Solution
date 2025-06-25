//using DesignPatterns.Models;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatterns_ASPNETCore.Models.ViewModels;

namespace DesignPatterns_ASPNETCore.Strategies
{
    public class ProductWithOutCategoryStrategy : IProductStrategy
    {
        public void Add(FormProductViewModel viewModel, IUnitOfWork unitOfWork)
        {
            // Crear el producto
            var product = new Product();
            product.Name = viewModel.Name;
            product.UnitsInStock = viewModel.UnitsInStock;
            product.UnitPrice = viewModel.UnitPrice;

            // Como no se ha seleccionado una categoria crear una categoria
            //  Crear una nueva categoria con los datos ingresados en la GUI
            //  para esto usamos el ViewModel.
            var newCategory = new Category();
            newCategory.Name = viewModel.OtherCategory;

            newCategory.CategoryId = Guid.NewGuid();// Generar una nueva categoria.
                                                    //  Asignamos el nuevo "CategoryId" de la categoria al campo respectivo 
                                                    //  de la clase "Product".
            product.CategoryId = newCategory.CategoryId;

            // Agregar al category al repositorio
            unitOfWork.Categories.Add(newCategory);//0

            // Agregar el producto al repositorio
            unitOfWork.Products.Add(product);//1

            // Enviar los datos a la Base de Datos
            unitOfWork.Save();//
        }
    }
}
