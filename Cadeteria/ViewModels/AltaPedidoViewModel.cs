using Cadeteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class AltaPedidoViewModel
    {
        private List<Cadete> listaCadetes;
        private List<Cliente> listaClientes;
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Cliente> ListaClientes { get => listaClientes; set => listaClientes = value; }

        public AltaPedidoViewModel(List<Cadete> _listaCadetes,List<Cliente> _listaClientes)
        {
            ListaCadetes = _listaCadetes;
            ListaClientes = _listaClientes;
        }
    }
}
