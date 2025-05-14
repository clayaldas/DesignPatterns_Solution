using DesignPatterns.Utilities.FactoryMethod_Profit.Factories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns_ASPNETCore.Controllers
{
    public class ProducDetailController : Controller
    {
        // Pasar desde la URL un parametro a la vista del controller
        public IActionResult Index(decimal total)
        {
            // Factory Method
            // Frabrica 
            LocalProfitFactory localProfitFactory = new LocalProfitFactory(0.3m);
            // Frabrica 
            ForeignProfitFactory foreignProfitFactory = new ForeignProfitFactory(0.3m, 0.16m);
            
            // Products
            var localProfit = localProfitFactory.GetProfit();
            var foreignProfit = foreignProfitFactory.GetProfit();

            // Calcular las ganancias en ventas los productos vendidos localmente.
            ViewBag.totalLocal = total + localProfit.Profit(total);

            // Calcular las ganancias en ventas los productos vendidos al extranjero.
            ViewBag.totalForeign = total + foreignProfit.Profit(total);

            // retorna el HTML
            return View();
        }
    }
}
