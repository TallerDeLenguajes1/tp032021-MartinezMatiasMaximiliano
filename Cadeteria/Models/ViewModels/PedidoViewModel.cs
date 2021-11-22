using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadeteria.ViewModels;
using Cadeteria.Entities;

namespace Cadeteria.ViewModels
{
    public class PedidoViewModel
    {
        public int ID { get; set; }
        public string Obs { get; set; }
        public Estado EstadoPedido { get; set; }
        public ClienteViewModel ClientePedido { get; set; }
    }

    public class ListaPedidosViewModel {
        public List<PedidoViewModel> listaPedidos = new();
    }

    public class NuevoPedidoViewModel {
        public List<CadeteViewModel> listaCadetes = new();
        public PedidoViewModel PedidoVM;
        public int ClienteID;
        public int CadeteID;
    }
}
