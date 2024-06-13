using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGStore.Models
{
    public class Sesion
    {
        [Key]
        public string IdSesion { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        //Constructor vacio
        public Sesion()
        {
        }
        //Constructor con todas las propiedades
        public Sesion(string idSesion, int idUsuario, Usuario usuario)
        {
            IdSesion = idSesion;
            IdUsuario = idUsuario;
            Usuario = usuario;
        }
        //Constructor con todas las propiedades menos el id
        public Sesion(int idUsuario, Usuario usuario)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
        }
        //Constructor con todas las propiedades menos el usuario
        public Sesion(string idSesion, int idUsuario)
        {
            IdSesion = idSesion;
            IdUsuario = idUsuario;
        }
    }
}
