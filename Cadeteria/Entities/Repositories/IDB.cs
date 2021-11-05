using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IDB
    {
        public IRepositorioCadete RepositorioCadete { get; set; }
        public IRepositorioCliente RepositorioCliente { get; set; }
        public IRepositorioPedido RepositorioPedido { get; set; }
    }

    public class DBSQLite : IDB
    {

        public IRepositorioCadete RepositorioCadete { get; set; }
        public IRepositorioCliente RepositorioCliente { get; set; }
        public IRepositorioPedido RepositorioPedido { get; set; }

        public DBSQLite(string _ConnectionString)
        {
            RepositorioCadete = new SQLiteCadete(_ConnectionString);
            RepositorioCliente = new SQLiteCliente(_ConnectionString);
            RepositorioPedido = new SQLitePedido(_ConnectionString);
            
        }
    }

 
}
