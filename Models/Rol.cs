using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace VGStore.Models
{
	public class Rol
	{


		[Key]
		public int IdRol { get; set; }
		[Required]
		public string NombreRol { get; set; }
		[Required]
		public string Descripcion { get; set; }
		[Required]
		public Boolean EstadoRol { get; set; }

		public Rol(string nombreRol, string? descripcion, bool estadoRol)
		{
			NombreRol = nombreRol;
			Descripcion = descripcion;
			EstadoRol = estadoRol;
		}

		public Rol(int idRol, string nombreRol, string? descripcion, bool estadoRol)
		{
			IdRol = idRol;
			NombreRol = nombreRol;
			Descripcion = descripcion;
			EstadoRol = estadoRol;
		}
	}
}
