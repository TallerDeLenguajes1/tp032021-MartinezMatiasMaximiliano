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
        Rol rol;

        public int ID { get => iD; set => iD = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public Rol Rol { get => rol; set => rol = value; }
    }
}
