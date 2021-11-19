using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public class Persona
    {
        //atributos
        int id;
        int usuarioID;
        string nombre;
        string direccion;
        string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int UsuarioID { get => usuarioID; set => usuarioID = value; }
    }
}
