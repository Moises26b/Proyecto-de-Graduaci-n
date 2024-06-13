﻿using Microsoft.AspNetCore.Mvc;
using VGStore.Models;
using VGStore.Statics;

namespace VGStore.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Login()
		{
			return View("login2");
		}
        public IActionResult Login2()
        {
            return View();
        }

        [HttpPost]
		public string EncontrarUsuario()
		{
			var userInfo = Request.Form["username"];
			var usuario = LoginService.EncontrarUsuario(userInfo);
			if (usuario == null)
			{
				return "false";
			}
			return "true";
		}

		[HttpPost]
		public IActionResult LoginAttempt()
		{
			var username = Request.Form["username"];
			var password = Request.Form["password"];
			var Usuario = LoginService.EncontrarUsuario(username);
			var passwordEnc = LoginService.EncriptarContraseña(password);
			if (Usuario == null)
			{
				ViewData["Error"] = "El usuario no existe";
			}
			else if (Usuario.Pwd != passwordEnc)
			{
				ViewData["Error"] = "La contraseña es incorrecta";
			}
			else
            {
                var fecha = DateOnly.FromDateTime(DateTime.Now);
				Usuario.UltimaConexion = fecha;
				CRUD.ActualizarUsuario(Usuario);
                CookieOptions cookieOptions = LoginService.GetCookieOptions();
				string token = LoginService.CrearSesion(Usuario.IdUsuario);
				HttpContext.Response.Cookies.Append("token", token, cookieOptions);
				var sesion = CRUD.EncontrarSesionPorGUID(token);
				var usuario = CRUD.EncontrarUsuarioPorId(sesion.IdUsuario);
				ViewData["username"] = usuario.Username;
				Rol rol = LoginService.EncontrarRolesPorUsuario(usuario.IdUsuario);
                if (rol!=null)
                {
                    if (rol != null) { ViewData["rol"] = rol.NombreRol; }
                }
                //return View("~/Views/Home/Index.cshtml");
				return Redirect("~/home/index");
			}
			ViewData["Username"] = username;
			ViewData["Password"] = password;
			return View("Login2");
		}

		public IActionResult Registro()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RegisterAttempt()
		{
			var username = Request.Form["username"];
			var correo = Request.Form["correo"];
			var nombre = Request.Form["nombre"];
			var password = Request.Form["password"];
			var confirm_password = Request.Form["confirm_password"];
			var edad = 0;
			try{
				edad = int.Parse(Request.Form["edad"]);
			}catch(Exception e){}
			var domicilio = Request.Form["domicilio"];
			if (edad == 0)
			{
				ViewData["Error"] = "Los datos ingresados para edad no son validos";
			}
			else if (password != confirm_password)
			{
				ViewData["Error"] = "Las contraseñas no coinciden";
			}
			else if (correo == "" || username == "" || nombre == "" || password == "" || confirm_password == "" || domicilio == "")
			{
				ViewData["Error"] = "Todos los campos son requeridos";
			}
			else if (CRUD.EncontrarUsuarioPorUsername(username) != null)
			{
				ViewData["Error"] = "El nombre de usuario ya esta registrado";
			}
			else if (CRUD.EncontrarUsuarioPorCorreo(correo) != null)
			{
				ViewData["Error"] = "El correo ya esta registrado";
			}
			else
			{
				password = LoginService.EncriptarContraseña(password);
				var User = new Usuario(nombre, username, edad, correo, domicilio, password, true);
				CRUD.InsertarUsuario(User);
				return View("Login2");
			}
			ViewData["Username"] = username;
			ViewData["Nombre"] = nombre;
			ViewData["Password"] = password;
			ViewData["Edad"] = edad;
			ViewData["Correo"] = correo;
			ViewData["Domicilio"] = domicilio;
			return View("Registro");
		}
		public IActionResult Logout()
		{
			LoginService.CerrarSesion(HttpContext.Request.Cookies["token"]);
			HttpContext.Response.Cookies.Delete("token");
			return Redirect("/login/login");
		}
	}
}
