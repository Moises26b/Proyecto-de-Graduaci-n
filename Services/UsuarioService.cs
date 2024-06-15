using Microsoft.EntityFrameworkCore;
using Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly ContextoDeUsuario _context;

		public UsuarioService(ContextoDeUsuario context)
		{
			_context = context;
		}

		public async Task<Usuario> GetUsuario(string correo, string pwd)
		{
			Usuario usuario = await _context.Usuarios.Where(u => u.Correo == correo && u.Pwd == pwd)
				.FirstOrDefaultAsync();

			return usuario;			
		}


		public async Task<Usuario> SaveUsuario(Usuario usuario)
		{
			_context.Usuarios.Add(usuario);
			await _context.SaveChangesAsync();
			return usuario;
		}
	}
}
