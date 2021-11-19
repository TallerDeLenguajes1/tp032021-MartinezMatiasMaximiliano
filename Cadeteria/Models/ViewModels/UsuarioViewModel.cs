using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class UsuarioViewModel
    {
    }

    public class UsuarioAltaViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas ingresadas no son iguales")]
        public string RePassword { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }

        [Required]
        public int Rol { get; set; }
    }
}
