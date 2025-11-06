using Microsoft.AspNetCore.Mvc;
using Utilities.DesignPatterns.FactoryMethod_Profit;
using Utilities.DesignPatterns.FactoryMethod_Profit.Factories;

namespace ASPNETCore_DesignPatterns.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //LocalProfitFactory localProfitFactory = new LocalProfitFactory(0.4m);

            ForeignProfitFactory foreignProfitFactory = new ForeignProfitFactory(0.7m, 0.16m);

            // Products: calcular las ganancias para las ventas locales
            var localProfit = localProfitFactory.GetProfit();
            var foreignProfit = foreignProfitFactory.GetProfit();
            
            // ViewBag: Diccionario dinamico y permite agregar/crear variables en backend 
            //          y luego estas variables del diccionario referenciales en frontend
            ViewBag.totalLocal = total + localProfit.Profit(total);
            ViewBag.totalForeign = total + foreignProfit.Profit(total);

            // pasar los datos del ViewBag al frontend y visualizar el HTML
            return View();
        }
    }
}
