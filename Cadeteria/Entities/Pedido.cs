using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public enum Estado { Entregado, EnProceso, Cancelado }
    public enum TipoPedido { Express, Delicado, Ecologico }

    public class Pedido
    {
        private static int costoFijo = 150;

        //atributos
        int iD;
        string obs;
        Cliente clientePedido;
        Estado estadoPedido;
        TipoPedido tipoEnvio;

        public int ID { get => iD; set => iD = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente ClientePedido { get => clientePedido; set => clientePedido = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }

        //constructores
        public Pedido() { }

        public Pedido(string _Obs, Cliente _ClientePedido)
        {
            this.obs = _Obs;
            this.clientePedido = _ClientePedido;
        }



        //metodos
        public float CalcularCosto(bool _Cupon)
        {
            float total = 0;
            switch (this.tipoEnvio)
            {
                case TipoPedido.Express:
                    total = (float)(costoFijo * 1.25);
                    break;
                case TipoPedido.Delicado:
                    total = (float)(costoFijo * 1.30);
                    break;
                case TipoPedido.Ecologico:
                    total = costoFijo;
                    break;
            }
            if (_Cupon)
            {
                total -= (float)(total * 0.10);
            }
            return total;
        }
    }
}
