using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGStore.Models
{
	public class UsuarioRol
	{
		//Documentacion de la clase UsuarioRol
		//Clase que representa la tabla intermedia entre Usuario y Rol
		//Esta clase tiene dos llaves primarias, una para el id del usuario y otra para el id del rol
		[Key, Column(Order = 0)]
		public int IdUsuario { get; set; }
		[ForeignKey("IdUsuario")]
		public Usuario Usuario { get; set; }
		[Required]
		public int IdRol { get; set; }
		[ForeignKey("IdRol")]
		public Rol Rol { get; set; }
		public UsuarioRol()
		{
		}
		public UsuarioRol(int idUsuario, Usuario usuario, int idRol, Rol rol)
		{
			IdUsuario = idUsuario;
			Usuario = usuario;
			IdRol = idRol;
			Rol = rol;
		}
		public UsuarioRol(Usuario usuario, Rol rol)
		{
			Usuario = usuario;
			Rol = rol;
		}
		public UsuarioRol(int idUsuario, int idRol)
		{
			IdUsuario = idUsuario;
			IdRol = idRol;
		}
	}
}
