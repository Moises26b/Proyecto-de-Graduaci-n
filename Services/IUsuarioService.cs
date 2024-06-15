using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Services
{
	public interface IUsuarioService
	{
		Task<Usuario> GetUsuario(string correo, string contraseña);
		Task<Usuario> SaveUsuario(Usuario usuario);
	}
}
