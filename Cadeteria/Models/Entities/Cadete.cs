using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public class Cadete : Persona
    {
        List<Pedido> listaPedidos;

        public Cadete() { }

        public int PedidosDelCadete()     
        {
            if (listaPedidos != null)
            {
                return listaPedidos.Count();
            }
            else
            {
                return 0;
            }
        }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
    }
}
