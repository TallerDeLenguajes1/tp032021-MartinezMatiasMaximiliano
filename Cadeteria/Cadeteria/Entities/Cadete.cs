using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public enum  TipoVehiculo { Bicicleta, Auto, Moto }
    public class Cadete : Persona
    {
        //atributos
        int cadeteriaID;
        TipoVehiculo vehiculo;
        List<Pedido> listaPedidos;

        public int CadeteriaID { get => cadeteriaID; set => cadeteriaID = value; }
        public TipoVehiculo Vehiculo { get => vehiculo; set => vehiculo = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        //constructor
        public Cadete() { }
        public Cadete(int _Id, string _Nombre, string _Direccion, string _Telefono,TipoVehiculo _TipoVehiculo)
        {
            this.Id = _Id;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
            this.CadeteriaID = 1;
            this.Vehiculo = _TipoVehiculo;
            listaPedidos = new List<Pedido>();
        }

        //metodos
        public int PedidosDelCadete()
        {
            if (listaPedidos != null)
            {
                return listaPedidos.Count();
            }
            else
            {
                return 0;
            }
        }
    }
}
//public void CambiarVehiculo(int _NuevoVehiculo) { this.vehiculo = (TipoVehiculo)_NuevoVehiculo; }
