using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boolean = System.Boolean;

namespace VGStore.Models
{
	public class Usuario
	{
		[Key]
		public int IdUsuario { get; set; }
		[Required]
		public string NombreCompleto { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public int Edad {  get; set; }
		[Required]
		public string Correo { get; set; }
		[Required]
		public string Domicilio { get; set; }
		[Required]
		public string Pwd { get; set; }
		[Required]
		public DateOnly UltimaConexion { get; set; }
		[Required]
        public Boolean EstadoUsuario { get; set; }

        public Usuario(int idUsuario, string nombreCompleto, string username, int edad, string correo, string domicilio, string pwd, DateOnly ultimaConexion, Boolean estadoUsuario)
        {
            IdUsuario = idUsuario;
            NombreCompleto = nombreCompleto;
            Username = username;
			Edad = edad;
			Correo = correo;
			Domicilio = domicilio;
			Pwd = pwd;	
			UltimaConexion = ultimaConexion;
			EstadoUsuario = estadoUsuario;
        }

		//Constructor para crear un nuevo usuario sin id ni ultima conexion
		public Usuario(string nombreCompleto, string username, int edad, string correo, string domicilio, string pwd, Boolean estadoUsuario)
		{
			NombreCompleto = nombreCompleto;
			Username = username;
			Edad = edad;
			Correo = correo;
			Domicilio = domicilio;
			Pwd = pwd;
			EstadoUsuario = estadoUsuario;
		}
        //Constructor para crear un nuevo usuario sin id
		public Usuario(string nombreCompleto, string username, int edad, string correo, string domicilio, string pwd, DateOnly ultimaConexion, Boolean estadoUsuario)
		{
            NombreCompleto = nombreCompleto;
            Username = username;
            Edad = edad;
            Correo = correo;
            Domicilio = domicilio;
            Pwd = pwd;
            UltimaConexion = ultimaConexion;
            EstadoUsuario = estadoUsuario;
        }
    }
}
