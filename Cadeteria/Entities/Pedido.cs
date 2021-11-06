using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public enum Estado { Entregado, EnProceso, Cancelado }

    public class Pedido
    {
        //atributos
        int iD;
        string obs;
        Estado estadoPedido;
        Cliente clientePedido;

        public int ID { get => iD; set => iD = value; }
        public string Obs { get => obs; set => obs = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public Cliente ClientePedido { get => clientePedido; set => clientePedido = value; }

        //constructores
        public Pedido() { }

        public Pedido(string _Obs,Cliente _ClientePedido, int _EstadoPedido)
        {
            this.obs = _Obs;
            this.ClientePedido = _ClientePedido;
            this.EstadoPedido = (Estado)_EstadoPedido;
        }
        //metodos       
    }
}


