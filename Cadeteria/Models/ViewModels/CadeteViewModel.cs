using Cadeteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.ViewModels
{
    public class CadeteViewModel
    {
    }


    public class CadeteAltaViewModel
    {

    }

    public class ListaCadetesViewModel
    {

        private List<Cadete> listaCadetes;
        private List<Pedido> listaPedidos;

        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public ListaCadetesViewModel(List<Cadete> listaCadetes, List<Pedido> listaPedidos)
        {
            this.listaCadetes = listaCadetes;
            this.listaPedidos = listaPedidos;
        }

    }
}
