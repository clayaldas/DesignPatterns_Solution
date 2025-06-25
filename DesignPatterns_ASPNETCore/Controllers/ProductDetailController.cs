using DesignPatterns.Utilities.FactoryMethod_Profit.Factories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns_ASPNETCore.Controllers
{
  public class ProductDetailController : Controller
  {
    // Nueva variable
    private ProfitFactory _localProfitFactory;
    private ProfitFactory _foreignProfitFactory;

    // Creamos un constructor para inyectarlo
    public ProductDetailController(LocalProfitFactory localProfitFactory, ForeignProfitFactory foreignProfitFactory)
    {
      _localProfitFactory = localProfitFactory;
      _foreignProfitFactory = foreignProfitFactory;
    }

    // Pasamos en la View un parámetro (total) para ser receptado por la URL de la View.
    public IActionResult Index(decimal total)
    {
      // Esta clase es la fábrica requerida: Factory.
      // Le pasamos el porcentaje de ganancias.

      //****************************************************************************
      // NOTA: Ahora este código va en el contenedor del archivo Program.cs.
      //****************************************************************************
      //LocalProfitFactory localProfitFactory = new LocalProfitFactory(0.7m);
      //ForeignProfitFactory foreignProfitFactory = new ForeignProfitFactory(0.7m, 0.16m);

      // Products: son las reglas donde estan ganancias.
      // Esto regresa una instancia de la clase concreta que se va a utilizar.

      // nuevo codigo
      var localProfit = _localProfitFactory.GetProfit();
      //var localProfit = localProfitFactory.GetProfit();

      // Nuevo producto para obtener los ganancias para este producto.
      // nuevo codigo
      //var foreignProfitt = foreignProfitFactory.GetProfit();
      var foreignProfitt = _foreignProfitFactory.GetProfit();

      // Calcular las ganancias para mostrar en el View.
      // ViewBag: es un diccionario dinámico.
      // totalLocal: es un variable que se crear dinámicamente
      //              porque es un diccionario dinámico.
      ViewBag.totalLocal = total + localProfit.Profit(total);

      // Calcular las ganancias para mostrar en el View.
      ViewBag.totalForeign = total + foreignProfitt.Profit(total);

      return View();
    }
  }
}
