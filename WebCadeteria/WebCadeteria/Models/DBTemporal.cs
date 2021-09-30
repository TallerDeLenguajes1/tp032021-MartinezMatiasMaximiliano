using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebCadeteria.Entities;
using WebCadeteria.Helpers;

namespace WebCadeteria.Entities
{
    public class DBTemporal
    {
        public string pathCadetes = "listaCadetes.json";
        public string pathPedidos = "listaPedidos.json";


        private Cadeteria miCadeteria;
        public Cadeteria MiCadeteria { get => miCadeteria; set => miCadeteria = value; }



        public DBTemporal(string _Nombre)
        {
            miCadeteria = new Cadeteria(_Nombre);

            if (File.Exists(pathCadetes))
            {
                miCadeteria.ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(HelperModules.ReadFile(pathCadetes));
            }

            if (File.Exists(pathPedidos))
            {
                miCadeteria.ListaPedidos = JsonSerializer.Deserialize<List<Pedido>>(HelperModules.ReadFile(pathPedidos));
            }
        }
    }
}

//if (File.Exists(pathCadetes))
//{
//    miCadeteria.ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(HelperModules.ReadFile(pathCadetes));

//    foreach (var cadete in miCadeteria.ListaCadetes)
//    {
//        foreach (var pedido in cadete.ListaPedidos)
//        {
//            miCadeteria.ListaPedidos.Add(pedido);
//        }
//    }
//}
