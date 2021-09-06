using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCadeteria.Entities
{
    class Cadeteria
    {
        private string nombre;
        private List<Cadete> listaCadetes = new List<Cadete>();

        public string Nombre { get => nombre; set => nombre = value; }

        public Cadeteria(string _Nombre)
        {
            this.nombre = _Nombre;
        }
    }
}
