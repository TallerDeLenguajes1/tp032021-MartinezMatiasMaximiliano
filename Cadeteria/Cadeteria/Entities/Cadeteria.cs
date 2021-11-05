using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public class Cadeteria
    {
        //atributos
        string nombre;
        List<Cadete> listaCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

        //constructor
        public Cadeteria(string _Nombre)
        {
            this.Nombre = _Nombre;
            ListaCadetes = new List<Cadete>();
        }
        //metodos
    }
}
