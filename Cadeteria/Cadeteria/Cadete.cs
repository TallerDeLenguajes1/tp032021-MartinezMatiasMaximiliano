using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    class Cadete
    {
        private static int count = 0;

        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listaPedidos = new List<Pedido>();

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cadete() { }

        public Cadete(string _Nombre, string _Direccion, string _Telefono) {
            this.id = count++;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }

        public void AgregarPedido(Pedido _Pedido)
        {
            listaPedidos.Add(_Pedido);
        }

        public void QuitarPedido() {
            foreach (var item in listaPedidos)
            {

            }
        }


    }
}
