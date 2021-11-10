using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioUsuario
    {
        bool UsuarioExiste(string Username, string Password);
        void AltaUsuario();
        void DesactivarUsuario();
        void BorrarUsuario();
        void ModificarUsuario();
    }
}
