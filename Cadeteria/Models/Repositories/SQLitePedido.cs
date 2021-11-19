using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public class SQLitePedido : IRepositorioPedido
    {
        private readonly string StringDeConexion;

        public SQLitePedido(string _ConnectionString)
        {
            StringDeConexion = _ConnectionString;
        }

        public List<Pedido> GetAllPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = "SELECT * FROM Pedidos WHERE Activo = @estado";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@estado", 1);
                    using (SQLiteDataReader PedidoLeido = command.ExecuteReader())
                    {

                        while (PedidoLeido.Read())
                        {
                            Pedido Pedido = new Pedido()
                            {
                                ID = Convert.ToInt32(PedidoLeido["PedidoID"]),
                                Obs = PedidoLeido["observacionPedido"].ToString(),
                                EstadoPedido = (Estado)Convert.ToInt32(PedidoLeido["estadoPedido"]),
                            };

                            string QueryCliente = "SELECT * FROM clientes WHERE clienteID = @clienteID";
                            using (SQLiteCommand command2 = new SQLiteCommand(QueryCliente, connection))
                            {
                                command2.Parameters.AddWithValue("@clienteID", PedidoLeido["clienteID"]);
                                using (SQLiteDataReader ClienteLeido = command2.ExecuteReader())
                                {
                                    ClienteLeido.Read();
                                    Pedido.ClientePedido = new Cliente()
                                    {
                                        Nombre = ClienteLeido["nombreCliente"].ToString(),
                                        Direccion = ClienteLeido["direccionCliente"].ToString(),
                                        Telefono = ClienteLeido["telefonoCliente"].ToString()
                                    };
                                }
                            }
                            listaPedidos.Add(Pedido);
                        }
                    }
                }
                connection.Close();
            }
            return listaPedidos;
        }

        public List<Pedido> GetAllPedidosDeCadete(int ID)
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = "SELECT * FROM Pedidos WHERE activo = @activo AND cadeteID = @CadeteID" ;

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@activo", 1);
                    command.Parameters.AddWithValue("@CadeteID", ID);
                    using (SQLiteDataReader PedidoLeido = command.ExecuteReader())
                    {
                        while (PedidoLeido.Read())
                        {
                            Pedido Pedido = new Pedido()
                            {
                                ID = Convert.ToInt32(PedidoLeido["pedidoID"]),
                                Obs = PedidoLeido["obs"].ToString(),
                                EstadoPedido = (Estado)Convert.ToInt32(PedidoLeido["estado"]),
                            };

                            string QueryCliente = "SELECT * FROM Clientes WHERE clienteID = @clienteID";
                            using (SQLiteCommand command2 = new SQLiteCommand(QueryCliente, connection))
                            {
                                command2.Parameters.AddWithValue("@clienteID", Convert.ToInt32(PedidoLeido["clienteID"]));
                                using (SQLiteDataReader ClienteLeido = command2.ExecuteReader())
                                {
                                    ClienteLeido.Read();
                                    Pedido.ClientePedido = new Cliente()
                                    {
                                        Nombre = ClienteLeido["nombre"].ToString(),
                                        Direccion = ClienteLeido["direccion"].ToString(),
                                        Telefono = ClienteLeido["telefono"].ToString()
                                    };
                                }
                            }
                            listaPedidos.Add(Pedido);
                        }
                    }
                }
                connection.Close();
            }
            return listaPedidos;
        }

        public Pedido GetPedidoByID(int ID)
        {
            Pedido Pedido = null;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = $"SELECT * FROM Pedidos WHERE PedidoID = {ID}";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Pedido = new Pedido()
                        {
                            ID = Convert.ToInt32(reader["PedidoID"]),
                            Obs = reader["observacionPedido"].ToString(),
                        };
                    }
                }
                connection.Close();
            }
            return Pedido;
        }

        public void SavePedido(Pedido Pedido, int CadeteID, int ClienteID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"INSERT INTO Pedidos (observacionPedido,estadoPedido,clienteID,cadeteID) VALUES (@observacionPedido,@estadoPedido,@clienteID,@cadeteID);";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@observacionPedido", Pedido.Obs);
                    command.Parameters.AddWithValue("@estadoPedido", Pedido.EstadoPedido);
                    command.Parameters.AddWithValue("@clienteID", ClienteID);
                    command.Parameters.AddWithValue("@cadeteID", CadeteID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DesactivarPedido(int ID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"UPDATE Pedidos set Activo = 0 where PedidoID = {ID}";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    int AffectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarPedido(int ID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"DELETE FROM Pedidos Where PedidoID = {ID}";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    int AffectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ModificarPedido(Pedido Pedido) { }

        public List<Pedido> GetAllPedidos(string NombreCliente)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = "SELECT * FROM PedidosPorCliente WHERE nombreCliente = @nombreCliente";

                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("nombreCliente", NombreCliente);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido()
                            {
                                ID = Convert.ToInt32(reader["clienteID"]),
                                Obs = reader["observacion"].ToString(),
                                EstadoPedido = (Estado)reader["estadoPedido"]
                            };

                            listaPedidos.Add(pedido);
                        }
                    }
                }


            }
            return listaPedidos;
        }
    }
}
