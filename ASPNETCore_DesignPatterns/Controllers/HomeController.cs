using ASPNETCore_DesignPatterns.Configuration;
using ASPNETCore_DesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Utilities.DesignPatterns.Singleton;

namespace ASPNETCore_DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        
        //private readonly ILogger<HomeController> _logger;
        private readonly CustomConfiguration _configuration;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    //_logger = logger;
        //}
        // Inyeccion de dependecias
        public HomeController(IOptions<CustomConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        // Vista HTML de la pagina (index)
        public IActionResult Index()
        {
            //Log log = Log.GetIntance("log.txt");
            //log.SaveFile("Ingreso a la pagina: Index");

            Log log = Log.GetIntance(_configuration.FileName);
            log.SaveFile("Ingreso a la pagina: Index");

            //Mostrar la pagina
            return View();
        }

        public IActionResult Privacy()
        {
            //Log log = Log.GetIntance("Log.txt");
            //log.SaveFile("Ingreso a la pagina: Privacy");

            Log log = Log.GetIntance(_configuration.FileName);
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
