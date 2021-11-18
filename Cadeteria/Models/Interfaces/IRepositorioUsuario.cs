using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioUsuario
    {
        Usuario ValidarUsuario(string Username,string Password);
        bool SaveUsuario(Usuario Usuario);
        bool DesactivarUsuario(int ID);
        bool BorrarUsuario(int ID);
        void ModificarUsuario();
    }
}
