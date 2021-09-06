using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCadeteria.Entities
{
    public class Pedido
    {
        public enum EnumEstado {Entregado,Cancelado,EnProceso}
        private static int count = 0;

        private int nro;
        private string obs;
        private Cliente cliente;
        private EnumEstado estado;

        public int Nro { get => nro; set => nro = value; }
        public static int Count { get => count; set => count = value; }
        public string Obs { get => obs; set => obs = value; }
        internal EnumEstado Estado { get => estado; set => estado = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }

        public Pedido() { }

        public Pedido(string _Obs, EnumEstado _Estado, string _Nombre, string _Direccion, string _Telefono)
        {
            this.Nro = count++;
            this.Obs = _Obs;
            this.Estado = _Estado;
            this.Cliente = new Cliente(_Nombre,_Direccion,_Telefono);
        }
    }
}
