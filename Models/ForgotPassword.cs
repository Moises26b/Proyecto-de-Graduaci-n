using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_de_Diseño_y_Desarrollo_de_Sistemas.Models
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
    }

}