namespace VGStore.Models
{
	public class ContextoDeUsuario
	{
		public Usuario Usuario { get; set; }
		public Rol Rol { get; set; }
		public Sesion Sesion { get; set; }
		public ContextoDeUsuario(Usuario usuario, Rol rol, Sesion sesion)
		{
			Usuario = usuario;
			Rol = rol;
			Sesion = sesion;
		}
		public ContextoDeUsuario()
		{
		}
	}
}
