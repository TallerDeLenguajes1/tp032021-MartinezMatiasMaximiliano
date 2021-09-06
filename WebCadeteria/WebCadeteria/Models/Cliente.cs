using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCadeteria.Entities
{
    public class Cliente
    {
        private static int count = 0;

        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cliente() { }

        public Cliente(string _Nombre,string _Direccion,string _Telefono) {
            this.id = count++;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }
    }
}
