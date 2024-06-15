using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;
using System.Diagnostics;
using System.Security.Claims;


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
            ClaimsPrincipal claimsUser = HttpContext.User;
            string nombreUsuario = "";

            if (claimsUser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimsUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();

            }

            ViewData["nombreUsuario"] = nombreUsuario;

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

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion" , "Login");   
        }
    }
}
