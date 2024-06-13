using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace VGStore.Models
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
				//optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=VGSTORE;Trusted_Connection=True;TrustServerCertificate=True;");
				optionsBuilder.UseSqlServer("Server=DESKTOP-8DKT66K;Database=VGSTORE;Trusted_Connection=True;TrustServerCertificate=True;"); //Moises
                //optionsBuilder.UseSqlServer(@"Server=SQLServer.contoso.com;Database=VGSTORE;User Id=\;Password=;Trusted_Connection=False;TrustServerCertificate=True;Integrated Security=True;");
            }
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Sesion> Sesiones { get; set; }
		public DbSet<Rol> Roles { get; set; }
		public DbSet<UsuarioRol> UsuarioRoles { get; set; }
	}
}
