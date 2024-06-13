using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;
using System.Diagnostics;
using VGStore.Models;
using VGStore.Statics;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private void InitializeController(Sesion sesion)
        {

            Response.Redirect("~/login/login"); 


        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
