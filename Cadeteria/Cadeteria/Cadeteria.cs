using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
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

        public double calcularSalario(string _NombreCadete)
        {
            double salario = 0;
            return salario;
        }
    }
}
