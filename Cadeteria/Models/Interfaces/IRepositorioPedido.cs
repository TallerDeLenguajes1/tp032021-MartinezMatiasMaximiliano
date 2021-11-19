using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioPedido
    {
        void BorrarPedido(int ID);
        void DesactivarPedido(int ID);
        List<Pedido> GetAllPedidos();
        public List<Pedido> GetAllPedidosDeCadete(int ID);
        List<Pedido> GetAllPedidos(string NombreCliente);
        Pedido GetPedidoByID(int ID);
        void ModificarPedido(Pedido Pedido);
        void SavePedido(Pedido Pedido, int CadeteID, int ClienteID);
    }
}
