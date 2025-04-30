using DesignPatterns.Utilities;
using DesignPatterns_ASPNETCore.Configuration;
using DesignPatterns_ASPNETCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DesignPatterns_ASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly CustomConfiguration _configuration;

        // DI
        public HomeController(IOptions<CustomConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public IActionResult Index()
        {
            //Log.GetInstance("log.txt").SaveFile("Pagina Home");

            //Log log = Log.GetInstance("log.txt");
            //log.SaveFile("Hice click en: Home");

            Log log = Log.GetInstance(_configuration.FileName);
            log.SaveFile("Hice click en: Home");

            return View();
        }
        
        public IActionResult Privacy()
        {
            //Log log = Log.GetInstance("log.txt");
            //log.SaveFile("Hice click en: Privacy");

            Log log = Log.GetInstance(_configuration.FileName);
            log.SaveFile("Hice click en: Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
