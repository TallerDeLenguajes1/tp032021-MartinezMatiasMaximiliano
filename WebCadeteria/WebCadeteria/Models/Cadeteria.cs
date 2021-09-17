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
        private List<Cadete> listaCadetes = new List<Cadete>();
        private List<Pedido> listaPedidos = new List<Pedido>();

        public string Nombre { get => nombre; set => nombre = value;}
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadeteria() { }

        public Cadeteria(string _Nombre){
            this.nombre = _Nombre;
        }
    }
}
