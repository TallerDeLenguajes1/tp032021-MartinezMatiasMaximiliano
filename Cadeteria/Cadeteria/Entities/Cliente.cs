using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public class Cliente : Persona
    {
        public Cliente() { }

        //constructor
        public Cliente(int _Id, string _Nombre, string _Direccion, string _Telefono)
        {
            this.Id = _Id;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }

        //metodos

    }
}
