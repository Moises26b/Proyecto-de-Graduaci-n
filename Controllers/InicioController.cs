using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Statics;
using System.Diagnostics;
using System.Security.Claims;


namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Controllers
{

    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}