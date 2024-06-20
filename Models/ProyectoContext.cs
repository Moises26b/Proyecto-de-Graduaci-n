using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models
{
	public class ProyectoContext : DbContext
	{

		public ProyectoContext()
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Fundacion;Trusted_Connection=True;TrustServerCertificate=True;");
				optionsBuilder.UseSqlServer("Server=JuanMH;Database=Fundacion;Trusted_Connection=True;TrustServerCertificate=True;"); //Moises
               
            }
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Sesion> Sesiones { get; set; }
		public DbSet<Rol> Roles { get; set; }
		public DbSet<UsuarioRol> UsuarioRoles { get; set; }
	}
}
