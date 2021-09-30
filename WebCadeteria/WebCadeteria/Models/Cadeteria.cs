using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCadeteria.Entities
{
    public class Cadeteria
    {
        private string nombre;
        private List<Cadete> listaCadetes;
        private List<Pedido> listaPedidos;

        public string Nombre { get => nombre; set => nombre = value;}
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadeteria(string _Nombre)
        {
            listaCadetes = new List<Cadete>();
            listaPedidos = new List<Pedido>();
        }
    }
}
