using DesignPatterns.Utilities.FactoryMethod_Profit.Factories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns_ASPNETCore.Controllers
{
    public class ProducDetailController : Controller
    {
        private ProfitFactory _localProfitFactory;
        private ProfitFactory _foreignProfitFactory;

        // Crear un constructor para inyectar la o las clases
        public ProducDetailController(LocalProfitFactory localProfitFactory, ForeignProfitFactory foreignProfitFactory)
        {
            _localProfitFactory = localProfitFactory;
            _foreignProfitFactory = foreignProfitFactory;
        }

        // Pasar desde la URL un parametro a la vista del controller
        public IActionResult Index(decimal total)
        {
            // Factory Method
            // Frabrica 
            //LocalProfitFactory localProfitFactory = new LocalProfitFactory(0.3m);
            // Frabrica 
            //ForeignProfitFactory foreignProfitFactory = new ForeignProfitFactory(0.3m, 0.16m);
            
            // Products
            var localProfit = _localProfitFactory.GetProfit();
            var foreignProfit = _foreignProfitFactory.GetProfit();

            // Calcular las ganancias en ventas los productos vendidos localmente.
            ViewBag.totalLocal = total + localProfit.Profit(total);

            // Calcular las ganancias en ventas los productos vendidos al extranjero.
            ViewBag.totalForeign = total + foreignProfit.Profit(total);

            // retorna el HTML
            return View();
        }
    }
}
