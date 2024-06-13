using Microsoft.JSInterop;

namespace VGStore.Models
{
	public static class CRUD
	{
		//Esta clase contiene el CRUD de todas las tablas de la base de datos
		//Vamos a tener estas funciones:
		/*
			EncontrarTodos{NombreTabla}() -> List<{NombreTabla}>
			EncontrarPorId{NombreTabla}(int id) -> {NombreTabla}
			EncontrarPorNombre{NombreTabla}(string nombre) -> {NombreTabla} (En caso de que exista la propiedad de nombre)
			Insertar{NombreTabla}({NombreTabla} {NombreTabla}) -> void
			Actualizar{NombreTabla}({NombreTabla} {NombreTabla}) -> void
			Eliminar{NombreTabla}({NombreTabla} {NombreTabla}) -> void
		 */
		//Funciones de aqui en adelante:


		//CRUD de Usuario
		public static List<Usuario> ListarTodosLosUsuarios()
		{
			using (var db = new ProyectoContext())
			{
				return db.Usuarios.ToList();
			}
		}
		public static Usuario EncontrarUsuarioPorId(int id)
		{
			using (var db = new ProyectoContext())
			{
				return db.Usuarios.Find(id);
			}
		}
		public static Usuario EncontrarUsuarioPorNombre(string nombre)
		{
			using (var db = new ProyectoContext())
			{
				return db.Usuarios.Where(u => u.Username == nombre).FirstOrDefault();
			}
		}
		public static Usuario EncontrarUsuarioPorUsername(string username)
		{
			using (var db = new ProyectoContext())
			{
				return db.Usuarios.Where(u => u.Username == username).FirstOrDefault();
			}
		}
		public static Usuario EncontrarUsuarioPorCorreo(string correo)
		{
			using (var db = new ProyectoContext())
			{
				return db.Usuarios.Where(u => u.Correo == correo).FirstOrDefault();
			}
		}
		public static void InsertarUsuario(Usuario usuario)
		{
			using (var db = new ProyectoContext())
			{
				db.Usuarios.Add(usuario);
				db.SaveChanges();
			}
		}
		public static void ActualizarUsuario(Usuario usuario)
		{
			using (var db = new ProyectoContext())
			{
				db.Usuarios.Update(usuario);
				db.SaveChanges();
			}
		}
		public static void EliminarUsuario(Usuario usuario)
		{
			using (var db = new ProyectoContext())
			{
				db.Usuarios.Remove(usuario);
				db.SaveChanges();
			}
		}

		

		//CRUD de Sesion
		public static List<Sesion> ListarTodasLasSesiones()
		{
			using (var db = new ProyectoContext())
			{
				return db.Sesiones.ToList();
			}
		}
		public static Sesion EncontrarSesionPorGUID(string id)
		{
			using (var db = new ProyectoContext())
			{
				return db.Sesiones.Where(s => s.IdSesion == id).FirstOrDefault();
			}
		}
		public static List<Sesion> EncontrarSesionPorIdUsuario(int id)
		{
			using (var db = new ProyectoContext())
			{
				return db.Sesiones.Where(s => s.IdUsuario == id).ToList();
			}
		}
		public static void InsertarSesion(Sesion sesion)
		{
			using (var db = new ProyectoContext())
			{
				db.Sesiones.Add(sesion);
				db.SaveChanges();
			}
		}
		public static void ActualizarSesion(Sesion sesion)
		{
			using (var db = new ProyectoContext())
			{
				db.Sesiones.Update(sesion);
				db.SaveChanges();
			}
		}
		public static void EliminarSesion(Sesion sesion)
		{
			using (var db = new ProyectoContext())
			{
				db.Sesiones.Remove(sesion);
				db.SaveChanges();
			}
		}

		//CRUD de Rol
		public static List<Rol> ListarTodosLosRoles()
		{
			using (var db = new ProyectoContext())
			{
				return db.Roles.ToList();
			}
		}
		public static Rol EncontrarRolPorId(int id)
		{
			using (var db = new ProyectoContext())
			{
				return db.Roles.Find(id);
			}
		}
		public static Rol EncontrarRolPorNombre(string nombre)
		{
			using (var db = new ProyectoContext())
			{
				return db.Roles.Where(r => r.NombreRol == nombre).FirstOrDefault();
			}
		}
		public static void InsertarRol(Rol rol)
		{
			using (var db = new ProyectoContext())
			{
				db.Roles.Add(rol);
				db.SaveChanges();
			}
		}
		public static void ActualizarRol(Rol rol)
		{
			using (var db = new ProyectoContext())
			{
				db.Roles.Update(rol);
				db.SaveChanges();
			}
		}
		public static void EliminarRol(Rol rol)
		{
			using (var db = new ProyectoContext())
			{
				db.Roles.Remove(rol);
				db.SaveChanges();
			}
		}

		//CRUD de UsuarioRol
		public static List<UsuarioRol> ListarTodosLosIdDeUsuariosQueTienenRoles()
		{
			using (var db = new ProyectoContext())
			{
				return db.UsuarioRoles.ToList();
			}
		}
		public static UsuarioRol EncontrarRolDeUsuario(int id)
		{
			using (var db = new ProyectoContext())
			{
				try
				{
					UsuarioRol datos = db.UsuarioRoles.Find(id);
					if (datos == null)
					{
						return null;
					}
					return datos;
				}
				catch
				{
					return null;
				}
			}
		}
		public static List<Usuario> EncontrarUsuariosPorIdRol(int id)
		{
			using (var db = new ProyectoContext())
			{
				var usuarios = db.UsuarioRoles.Where(ur => ur.IdRol == id).ToList();
				List<Usuario> usuariosConRol = new List<Usuario>();
				foreach (var usuario in usuarios)
				{
					usuariosConRol.Add(usuario.Usuario);
				}
				return usuariosConRol;
			}
		}
		public static void AnadirRolAUsuario(UsuarioRol usuarioRol)
		{
			using (var db = new ProyectoContext())
			{
				db.UsuarioRoles.Add(usuarioRol);
				db.SaveChanges();
			}
		}
		public static void ActualizarRolDeUsuario(UsuarioRol usuarioRol)
		{
			using (var db = new ProyectoContext())
			{
				db.UsuarioRoles.Update(usuarioRol);
				db.SaveChanges();
			}
		}
		public static void EliminarRolAUsuario(UsuarioRol usuarioRol)
		{
			using (var db = new ProyectoContext())
			{
				db.UsuarioRoles.Remove(usuarioRol);
				db.SaveChanges();
			}
		}

	}
}
