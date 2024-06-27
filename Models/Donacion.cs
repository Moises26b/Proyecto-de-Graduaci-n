using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models
{
	public class Donacion
	{
		[Key]
		public int IdDonaciones { get; set; }
		[Required]
		public decimal monto { get; set; }
		[Required]
		public DateOnly fecha_donacion { get; set; }
		[Required]
		public int IdUsuario { get; set; }

		public Donacion(int IdDonaciones, decimal monto, DateOnly fecha_donacion, int IdUsuario)
		{
			IdDonaciones = IdDonaciones;
			monto = monto;
			fecha_donacion = fecha_donacion;
			IdUsuario = IdUsuario;
		}
		/* FALTA REALIZAR CONTROLLER Y VISTAS*/
	}
}
