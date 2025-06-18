using DesignPatterns.Repository;
using DesignPatterns_ASPNETCore.Models.ViewModels;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns_ASPNETCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            
            // Para recuparar los datos de la tabla Products se puede utilizar
            // a) Expresiones lambda
            // b) El lenguaje de consultas (LINQ)
            IEnumerable<ProductModel> products = from t in _unitOfWork.Products.Get()
                                                 select new ProductModel 
                                                 { 
                                                     ProductId = t.ProductId,
                                                     Name = t.Name,
                                                     UnitsInStock = t.UnitsInStock,
                                                     UnitPrice = t.UnitPrice,
                                                 };

            try
            {
                // enviar el control a la Vista (View) "Index"
                // y enviar los datos que estan el modelo para que 
                // se muestren en la vista (HTML)


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Liberar recursos
                // Conexiones
            }

            return View("Index", products);
        }
    }
}
