using Cadeteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class AltaPedidoViewModel
    {
        private string obs;
        private int estadoPedido; 

        private List<Cadete> listaCadetes;
        private List<Cliente> listaClientes;


        public string Obs { get => obs; set => obs = value; }
        public int EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Cliente> ListaClientes { get => listaClientes; set => listaClientes = value; }

        public AltaPedidoViewModel(List<Cadete> _listaCadetes,List<Cliente> _listaClientes)
        {
            ListaCadetes = _listaCadetes;
            ListaClientes = _listaClientes;
        }
    }
}
