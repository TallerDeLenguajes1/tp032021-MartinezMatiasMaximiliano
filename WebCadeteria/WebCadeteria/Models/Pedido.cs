using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCadeteria.Entities
{
    public enum EnumEstado {Entregado,EnProceso,Cancelado}

    public class Pedido
    {
        private static int count = 0;

        private int nro;
        private string obs;
        private Cliente cliente;
        private EnumEstado estado;

        public int Nro { get => nro; set => nro = value; }
        public static int Count { get => count; set => count = value; }
        public string Obs { get => obs; set => obs = value; }
        public EnumEstado Estado { get => estado; set => estado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

        public Pedido() { }

        public Pedido(string _Nombre, string _Direccion, string _Telefono,string _Obs, int _Estado)
        {
           
            this.Nro = ++count;
            this.Cliente = new Cliente(_Nombre,_Direccion,_Telefono);
            this.Obs = _Obs;
            this.Estado = (EnumEstado)_Estado;
        }

        public void CambiarEstado(EnumEstado _NuevoEstado){this.estado = _NuevoEstado;}
    }
}
