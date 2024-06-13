using Microsoft.AspNetCore.Mvc;
using VGStore.Models;
using VGStore.Statics;

namespace VGStore.Controllers
{
	public class RolController : Controller
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
			if (rol != null && rol.NombreRol == "ADMIN") { ViewData["rol"] = rol.NombreRol; }
			else { return Redirect("~/home/error"); }
			ViewData["username"] = CRUD.EncontrarUsuarioPorId(sesion.IdUsuario).Username;
			return null;
		}

		public IActionResult Listar()
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			var roles = CRUD.ListarTodosLosRoles();
			return View(roles);
		}

		public IActionResult Crear()
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			return View();
		}

		public IActionResult Editar(int id)
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			var rol = CRUD.EncontrarRolPorId(id);
			return View(rol);
		}

		public IActionResult Eliminar(int id)
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			var rol = CRUD.EncontrarRolPorId(id);
			CRUD.EliminarRol(rol);
			return RedirectToAction("Listar");
		}

		public IActionResult Guardar()
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			var idRol = 0;
			try
			{
				idRol = int.Parse(Request.Form["idRol"]);
			}
			catch (Exception e)
			{
				// Si la conversión falla, es un nuevo Rol y se inserta en la DB sin id.
			}

			var NombreRol = Request.Form["NombreRol"];
			string descripcion = HttpContext.Request.Form["descripcion"];
			var EstadoRol = Request.Form["EstadoRol"] == "Activo" ? true : false;

			if (idRol == 0)
			{
				var rol = new Rol(NombreRol, descripcion, EstadoRol);
				CRUD.InsertarRol(rol);
			}
			else
			{
				var rol = new Rol(idRol, NombreRol, descripcion, EstadoRol);
				CRUD.ActualizarRol(rol);
			}

			return RedirectToAction("Listar");
		}

		public IActionResult AdministrarRolUsuario(int id)
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			var usuario = CRUD.EncontrarUsuarioPorId(id);
			var roles = CRUD.ListarTodosLosRoles();
			ViewData["idUsuario"] = usuario.IdUsuario;
			ViewData["NombreUsuario"] = usuario.NombreCompleto;
			ViewData["Correo"] = usuario.Correo;
			ViewData["UsernameDisplay"] = usuario.Username;
			var rolactual = CRUD.EncontrarRolDeUsuario(id);
			if (rolactual != null)
			{
				ViewData["rolActual"] = rolactual.IdRol;
			}
			return View(roles);
		}

		public IActionResult Asignar()
		{
			Sesion sesion = CRUD.EncontrarSesionPorGUID(HttpContext.Request.Cookies["token"]);
			IActionResult result = InitializeController(sesion);
			if (result != null) { return result; }
			var idRol = 0;
			var idUsuario = 0;
			UsuarioRol rolUsuario = null;
			try
			{
				idUsuario = int.Parse(Request.Form["idUsuario"]);
				idRol = int.Parse(Request.Form["idRol"]);
				if (idUsuario == 0)
				{
					return Redirect("~/usuario/listusers");
				}
				rolUsuario = CRUD.EncontrarRolDeUsuario(idUsuario);
				if (idRol == 0 && rolUsuario != null)
				{
					CRUD.EliminarRolAUsuario(rolUsuario);
					return Redirect("~/usuario/listusers");
				}
			}
			catch (Exception e)
			{
				return Redirect("~/usuario/listusers");
			}

			var usuario = CRUD.EncontrarUsuarioPorId(idUsuario);
			var rol = CRUD.EncontrarRolPorId(idRol);
			if (usuario == null || rol == null)
			{
				return Redirect("~/usuario/listusers");
			}

			if (rolUsuario == null)
			{
				CRUD.AnadirRolAUsuario(new UsuarioRol(usuario.IdUsuario, rol.IdRol));
				return Redirect("~/usuario/listusers");
			}
			if (rolUsuario.IdRol == idRol)
			{
				return Redirect("~/usuario/listusers");
			}
			rolUsuario.IdRol = idRol;
			CRUD.ActualizarRolDeUsuario(rolUsuario);
			return Redirect("~/usuario/listusers");
		}
	}
}
