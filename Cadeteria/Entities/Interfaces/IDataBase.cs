using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IDataBase
    {
        public IRepositorioCadete RepositorioCadete { get; set; }
        public IRepositorioCliente RepositorioCliente { get; set; }
        public IRepositorioPedido RepositorioPedido { get; set; }
    }
}
