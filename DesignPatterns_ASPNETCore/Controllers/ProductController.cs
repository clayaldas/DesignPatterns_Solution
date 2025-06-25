using DesignPatterns_ASPNETCore.Models.ViewModels;
using DesignPatterns.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DesignPatterns.Models.Data;
using DesignPatterns_ASPNETCore.Strategies;

namespace DesignPatterns_ASPNETCore.Controllers
{
  public class ProductController : Controller
  {
    //  Patron Unit Of Work.
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
      // Podemos usar linq o expresiones lambda para recuperar los datos
      // que los tiene el Unit Of Work (esta es la fuente de datos).
      IEnumerable<ProductModel> products =
          from t in _unitOfWork.Products.Get()
          select new ProductModel
          {
            ProductId = t.ProductId,
            Name = t.Name,
            UnitsInStock = t.UnitsInStock,
            UnitPrice = t.UnitPrice,
          };

      return View("Index", products);
    }

    [HttpGet]
    public IActionResult Add()
    {
      GetCategoriesData();

      // Retornar las datos para que la vista "View" los visualice.
      return View();
    }

    [HttpPost]
    public IActionResult Add(FormProductViewModel viewModel)
    {
      //  Verificar que algunas de las validaciones (DataAnnotations) tienen asociados
      //  los campos de la clase "FormProductViewModel" no pasan la validación.
      if (!ModelState.IsValid)
      {
                ////  Si algún campo no pasa la validación entonces volver a mostrar el
                ////  formulario con los errores.
                ////  Volver a cargar los datos de la tabla "Categories" con el Unit Of Work.
                //var categories = _unitOfWork.Categories.Get();
                //ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
                ////  Mostrar nuevamente las datos en la Vista con los errores pero con los
                ////  datos el modelo "FormProductViewModel" para que sean los errores
                ////  corregidos.
                GetCategoriesData();

                return View("Add", viewModel);
      }

      // Utilizar el patron Strategy
      var context = viewModel.CategoryId == null
                ? new ProductContext( new ProductWithOutCategoryStrategy())
                : new ProductContext(new ProductWithCategoryStrategy());

       // ejecutar el contexto con la estrategia
       context.Add(viewModel, _unitOfWork);

        
      ////  Si se pasa todas las validaciones, creamos un nuevo producto y lo 
      ////  guardamos en la BD.
      //var product = new Product();
      //// Tomar los datos del ViewModel (GUI).
      //product.Name = viewModel.Name;
      //product.UnitsInStock = viewModel.UnitsInStock;
      //product.UnitPrice = viewModel.UnitPrice;

      ////  Si no se selecciona una categoria existente, se crea otra categoria con el 
      ////  nombre introducido en el campo "OtherCategory".
      //if (viewModel.CategoryId == null)
      //{
      //  //  Crear una nueva categoria con los datos ingresados en la GUI
      //  //  para esto usamos el ViewModel.
      //  var newCategory = new Category();
      //  newCategory.Name = viewModel.OtherCategory;
      //  newCategory.CategoryId = Guid.NewGuid();// Generar una nueva categoria.
      //  //  Asignamos el nuevo "CategoryId" de la categoria al campo respectivo 
      //  //  de la clase "Product".
      //  product.CategoryId = newCategory.CategoryId;

      //  //  Agregamos el neuvo registro de la categoria "newCategory" al repositorio
      //  //  por medio del patrón Unit Of Work.
      //  _unitOfWork.Categories.Add(newCategory);
      //}
      //else
      //{
      //  //  Si se ha seleccionado una categoria, asignar el "CategoryId" al campo
      //  //  de la clase "Product" que es de tipo "Guid".
      //  product.CategoryId = (Guid)viewModel.CategoryId;
      //}

      ////  Agregar el producto al repositorio por medio del Unit Of Work.
      //_unitOfWork.Products.Add(product);

      ////  Guardar los cambios en la Base de Datos, en las 2 tablas "Products y Categories"
      ////  o en ninguna. 
      //_unitOfWork.Save();

      //  Si todo es correcto, redirigir a la vista "View" Index para mostrar
      //  la lista de productos con los nuevos elementos agregados.
      return RedirectToAction("Index");
    }

    private void GetCategoriesData()
    {
            //  Unit Of Work para recuperar los datos de la tabla "Categories".
            //  y mostrarlos en un ComboBox.
            var categories = _unitOfWork.Categories.Get();

            //  ViewBag: Objeto para enviar datos del backend(ASPNET Core) a la vista/frontend (Razor).
            //  ViewBag.Categories: Se crea la variable llamada "Categories" o el nombre que se desee
            //          para pasar los datos la vista.
            //  SelectList: Es método helper de ASPNET que permite crear una lista de datos que serán
            //          mostrados en un ComboBox.
            //          categories: Es la fuente de los datos.
            //          CategoryId: Es el primary key de la tabla "Categories" con el cual se trabaja.
            //          Name: Es el campo que se va a mostrar realmente en el ComboBox.
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
    }
  }
}
