using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int UsuarioID { get; set; }

    }

    public class ListaClientesViewModel
    {
        public List<ClienteViewModel> listaClientes = new();
    }

    public class ClienteInfoViewModel
    {
        public ClienteViewModel ClienteVM;
        public List<PedidoViewModel> listaPedidosVM = new();
    }

}