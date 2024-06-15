using Microsoft.EntityFrameworkCore;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models
{
	public class ContextoDeUsuario : DbContext
	{

		public ContextoDeUsuario(DbContextOptions<ContextoDeUsuario> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }


	
		public Usuario Usuario { get; set; }
		public Rol Rol { get; set; }
		public Sesion Sesion { get; set; }
		public ContextoDeUsuario(Usuario usuario, Rol rol, Sesion sesion)
		{
			Usuario = usuario;
			Rol = rol;
			Sesion = sesion;
		}


	}
}