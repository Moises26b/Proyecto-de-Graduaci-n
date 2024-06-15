using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Statics;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Controllers
{
	public class UsuarioController : Controller
    {
        private IActionResult InitializeController(Sesion sesion)
		{
			try
			{
				if (sesion == null) { return Redirect("~/login/login"); }
				if (!LoginService.ValidateToken(sesion.IdSesion)) { return Redirect("~/login/login"); }
			}
			catch { return Redirect("~/login/login"); }
			Rol rol = LoginService.EncontrarRolesPorUsuario(sesion.IdUsuario);
            if (rol != null && rol.NombreRol=="ADMIN") { ViewData["rol"] = rol.NombreRol; }
            else { return Redirect("~/home/error"); }
            ViewData["username"] = CRUD.EncontrarUsuarioPorId(sesion.IdUsuario).Username;
            return null;
        }
        public IActionResult Index()
        {
            Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
            IActionResult result = InitializeController(sesion);
            if (result != null) { return result; }
            var users = CRUD.ListarTodosLosUsuarios();
			return View(users);
        }

        public IActionResult ListUsers()
        {
            Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
            IActionResult result = InitializeController(sesion);
            if (result != null) { return result; }
            var users = CRUD.ListarTodosLosUsuarios();
            return View(users);
        }

        public IActionResult CreateUser()
        {
            Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
            IActionResult result = InitializeController(sesion);
            if (result != null) { return result; }
            var items = new List<SelectListItem>
            {
				new SelectListItem {Text = "Activo", Value = "true"},
				new SelectListItem {Text = "Inactivo", Value = "false"}
			};
			ViewBag.EstadoUsuario = items;
			return View();
		}

        public IActionResult EditUser(int id)
        {
            Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
            IActionResult result = InitializeController(sesion);
            if (result != null) { return result; }
            var usuario = CRUD.EncontrarUsuarioPorId(id);
			return View("EditUser", usuario);
        }

        [HttpPost]
        public IActionResult SaveUser()
        {
            Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
            IActionResult result = InitializeController(sesion);
            if (result != null) { return result; }
            int IdUsuario = 0;
			try
            {
                IdUsuario=int.Parse(Request.Form["id"]);
            }catch(Exception e)
            {
				//Si la conversion falla, es un usuario nuevo y se inserta en al DB sin id.
			}
            var NombreCompleto = Request.Form["nombre"];
            var Username = Request.Form["username"];
            var Edad = int.Parse(Request.Form["edad"]);
            var Correo = Request.Form["correo"];
            var Domicilio = Request.Form["domicilio"];
            var pwd = Request.Form["password"];
            var EstadoUsuario = Request.Form["EstadoUsuario"] == "Activo" ? true : false;
            if(IdUsuario == 0)
            {
				var user = new Usuario(NombreCompleto, Username, Edad, Correo, Domicilio, pwd, EstadoUsuario);
				CRUD.InsertarUsuario(user);
				return RedirectToAction("ListUsers");
            }
            else { 
                Usuario tempUser = CRUD.EncontrarUsuarioPorId(IdUsuario);
                var UltimaConexion = tempUser.UltimaConexion;
                if (pwd != tempUser.Pwd)
                {
                    pwd = LoginService.EncriptarContraseña(pwd);
                }
                else
                {
                    pwd = tempUser.Pwd;
                }

                var user = new Usuario(IdUsuario, NombreCompleto, Username, Edad, Correo, Domicilio, pwd, UltimaConexion, EstadoUsuario);
                CRUD.ActualizarUsuario(user);
			}
			return RedirectToAction("ListUsers");
        }

        public IActionResult DeleteUser(int id)
        {
            Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
            IActionResult result = InitializeController(sesion);
            if (result != null) { return result; }
            CRUD.EliminarUsuario(CRUD.EncontrarUsuarioPorId(id));
            return RedirectToAction("ListUsers");
        }

    }
}
