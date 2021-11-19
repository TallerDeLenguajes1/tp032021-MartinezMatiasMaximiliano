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
        [Required(ErrorMessage ="El campo es requerido")]
        public string Username { get; set; }

[Required(ErrorMessage ="El campo es requerido")]
        public string Password { get; set; }

[Required(ErrorMessage ="El campo es requerido")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas ingresadas no son iguales")]
        public string RePassword { get; set; }

[Required(ErrorMessage ="El campo es requerido")]
        public string Nombre { get; set; }
[Required(ErrorMessage ="El campo es requerido")]
        public string Direccion { get; set; }
[Required(ErrorMessage ="El campo es requerido")]
        public string Telefono { get; set; }

[Required(ErrorMessage ="El campo es requerido")]
        public int Rol { get; set; }
    }
}
