using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioUsuario
    {
        bool UsuarioExiste(string Username, string Password);
        bool AltaUsuario(string Username, string Password);
        bool DesactivarUsuario(int ID);
        bool BorrarUsuario(int ID);
        void ModificarUsuario();
    }
}
