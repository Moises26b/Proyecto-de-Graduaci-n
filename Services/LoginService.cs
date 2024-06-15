using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;


namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Statics
{
    public static class LoginService
    {
        //A esta clase le falta manejar los Roles de los usuarios
        public static string CrearSesion(int IdUsuario)
        {
            var existeSesion = CRUD.EncontrarSesionPorIdUsuario(IdUsuario);
            if (existeSesion != null)
            {
                
                return existeSesion.IdSesion;
            }
            var token = Guid.NewGuid().ToString();
            var sesion = new Sesion(token, IdUsuario);
            CRUD.InsertarSesion(sesion);
            return token;
        }

        internal static CookieOptions GetCookieOptions()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(20);
            return cookieOptions;
        }

        public static bool ValidateToken(string token)
        {
			if (token == null)
            {
				return false;
			}
			var sesion = CRUD.EncontrarSesionPorGUID(token);
			if (sesion==null)
            {
				return false;
			}
			var usuario = CRUD.EncontrarUsuarioPorId(sesion.IdUsuario);
            if (usuario == null)
            {
				return false;
			}
			return true;
		}

        public static void CerrarSesion(string token)
        {
			var sesion = CRUD.EncontrarSesionPorGUID(token);
			CRUD.EliminarSesion(sesion);
		}

		public static String EncriptarContraseña(String contraseña)
		{
			if(contraseña == null)
            {
                return null;
            }                
            byte[] data = System.Text.Encoding.ASCII.GetBytes(contraseña);
			data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
			String hash = System.Text.Encoding.ASCII.GetString(data);
			return hash;
		}

        public static Usuario EncontrarUsuario(string userInfo)
        {
            Usuario usuario = null;
            Usuario usuarioPorUsername=CRUD.EncontrarUsuarioPorUsername(userInfo);
            if (usuarioPorUsername != null && usuarioPorUsername.EstadoUsuario==true)
            {
				usuario = usuarioPorUsername;
                return usuario;
			}
			Usuario usuarioPorCorreo = CRUD.EncontrarUsuarioPorCorreo(userInfo);
            if (usuarioPorCorreo != null && usuarioPorCorreo.EstadoUsuario == true)
            {
				usuario = usuarioPorCorreo;
				return usuario;
			}
            return null;
		}

        public static Rol EncontrarRolesPorUsuario(int IdUsuario)
        {
			var roles = CRUD.EncontrarRolDeUsuario(IdUsuario);
			if (roles == null)
            {
				return null;
			}
			return CRUD.EncontrarRolPorId(roles.IdRol);
		}

        
	}


}
