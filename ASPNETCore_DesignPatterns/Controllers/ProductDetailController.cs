using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Utilities.DesignPatterns.FactoryMethod_Profit.Factories;
//using Utilities.DesignPatterns.FactoryMethod_Profit.Factories;

namespace ASPNETCore_DesignPatterns.Controllers
{
    public class ProductDetailController : Controller
    {
        private LocalProfitFactory _localProfitFactory;
        private ForeignProfitFactory _foreignProfitFactory;
        // Inyectar las variables: por constructor

        public ProductDetailController(LocalProfitFactory localProfitFactory, 
            ForeignProfitFactory foreignProfitFactory)
        {
            _localProfitFactory = localProfitFactory;
            _foreignProfitFactory = foreignProfitFactory;
        }

        public IActionResult Index(decimal total)
        {
            //LocalProfitFactory localProfitFactory = new LocalProfitFactory(0.7m);
            var localProfit = _localProfitFactory.GetProfit();


            //ForeignProfitFactory foreignProfitFactory = new ForeignProfitFactory(0.7m, 0.16m);
           

            // Products: calcular las ganancias para las ventas locales
            //var localProfit = localProfitFactory.GetProfit();
            //var foreignProfit = foreignProfitFactory.GetProfit();
            var foreignProfit = _foreignProfitFactory.GetProfit();

            // ViewBag: Diccionario dinamico y permite agregar/crear variables en backend 
            //          y luego estas variables del diccionario referenciales en frontend
            ViewBag.totalLocal = total + localProfit.Profit(total);
            ViewBag.totalForeign = total + foreignProfit.Profit(total);

            // pasar los datos del ViewBag al frontend y visualizar el HTML
            return View();
        }
    }
}
