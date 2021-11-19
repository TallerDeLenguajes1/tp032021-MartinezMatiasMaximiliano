using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioUsuario
    {
        bool ValidarUsuario(Usuario Usuario);
        bool SaveUsuario(Usuario Usuario);
        Usuario GetUsuario(Usuario Usuario);
        int GetIDUsuario(Usuario Usuario);
        bool DesactivarUsuario(int ID);
        bool BorrarUsuario(int ID);
        void ModificarUsuario();
    }
}
