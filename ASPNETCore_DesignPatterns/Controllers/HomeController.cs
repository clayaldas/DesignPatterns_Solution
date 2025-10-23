using ASPNETCore_DesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Utilities.DesignPatterns.Singleton;

namespace ASPNETCore_DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //_logger = logger;
        }

        // Vista HTML de la pagina (index)
        public IActionResult Index()
        {
            Log log = Log.GetIntance("log.txt");
            log.SaveFile("Ingreso a la pagina: Index");
            
            //Mostrar la pagina
            return View();
        }

        public IActionResult Privacy()
        {
            Log log = Log.GetIntance("Log.txt");
            log.SaveFile("Ingreso a la pagina: Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
