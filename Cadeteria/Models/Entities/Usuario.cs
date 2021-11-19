using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public enum Rol
    {
        Admin = 2,
        Cadete = 1,
        Cliente = 0
    }

    public class Usuario
    {
        int iD;
        string username;
        string password;
        string nombre;
        string direccion;
        string telefono;
        Rol rol;

        public int ID { get => iD; set => iD = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public Rol Rol { get => rol; set => rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
