using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioCliente
    {
        void BorrarCliente(int Id);
        void DesactivarCliente(int Id);
        List<Cliente> GetAllClientes();
        Cliente GetClienteByID(int ID);
        int GetClienteID(int ID);
        void ModificarCliente(Cliente Cliente);
        void SaveCliente(Cliente Cliente);
    }
}
