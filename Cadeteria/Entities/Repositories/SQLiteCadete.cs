using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public class SQLiteCadete : IRepositorioCadete
    {
        private readonly string StringDeConexion;

        public SQLiteCadete(string _ConnectionString)
        {
            StringDeConexion = _ConnectionString;
        }

        public List<Cadete> GetAllCadetes()
        {
            List<Cadete> listaCadetes = new List<Cadete>();

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQueryCadetes = "SELECT * FROM Cadetes WHERE Activo = 1";
                connection.Open();

                using (SQLiteCommand LeerCadetes = new SQLiteCommand(SQLQueryCadetes, connection))
                {
                    using (SQLiteDataReader cadetesLeidos = LeerCadetes.ExecuteReader())
                    {
                        while (cadetesLeidos.Read())
                        {
                            Cadete Cadete = new Cadete()
                            {
                                Id = Convert.ToInt32(cadetesLeidos["CadeteID"]),
                                Nombre = cadetesLeidos["nombreCadete"].ToString(),
                                Direccion = cadetesLeidos["direccionCadete"].ToString(),
                                Telefono = cadetesLeidos["telefonoCadete"].ToString(),
                                CadeteriaID = 1,
                                ListaPedidos = new List<Pedido>()
                            };


                            string SQLQueryPedidos = "SELECT * FROM Pedidos WHERE cadeteID = @CadeteID";
                            using (SQLiteCommand LeerPedidos = new SQLiteCommand(SQLQueryPedidos, connection))
                            {
                                LeerPedidos.Parameters.AddWithValue("@CadeteID", Cadete.Id);
                                using (SQLiteDataReader PedidoDelCadete = LeerPedidos.ExecuteReader())
                                {
                                    while (PedidoDelCadete.Read())
                                    {
                                        Pedido Pedido = new Pedido()
                                        {
                                            ID = Convert.ToInt32(PedidoDelCadete["PedidoID"]),
                                            Obs = PedidoDelCadete["observacionPedido"].ToString(),
                                            EstadoPedido = (Estado)Convert.ToInt32(PedidoDelCadete["estadoPedido"])
                                        };

                                        string SQLQueryCliente = "SELECT * FROM clientes WHERE clienteID = @clienteID";
                                        using (SQLiteCommand LeerCliente = new SQLiteCommand(SQLQueryCliente, connection))
                                        {
                                            LeerCliente.Parameters.AddWithValue("@clienteID", PedidoDelCadete["clienteID"]);
                                            using (SQLiteDataReader ClienteLeido = LeerCliente.ExecuteReader())
                                            {
                                                ClienteLeido.Read();
                                                Cliente Cliente = new Cliente()
                                                {
                                                    Id = Convert.ToInt32(ClienteLeido["clienteID"]),
                                                    Nombre = ClienteLeido["nombreCliente"].ToString(),
                                                    Direccion = ClienteLeido["direccionCliente"].ToString(),
                                                    Telefono = ClienteLeido["telefonoCliente"].ToString()
                                                };
                                                Pedido.ClientePedido = Cliente;
                                            }
                                        }

                                        Cadete.ListaPedidos.Add(Pedido);
                                    }
                                }
                            }
                            listaCadetes.Add(Cadete);
                        }
                    }
                }
                connection.Close();
            }
            return listaCadetes;
        }

        public Cadete GetCadeteById(int ID)
        {
            Cadete CadeteLeido = null;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = $"SELECT * FROM Cadetes WHERE CadeteID = @CadeteID";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@CadeteID",ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        CadeteLeido = new Cadete()
                        {
                            Id = Convert.ToInt32(reader["CadeteID"]),
                            Nombre = reader["nombreCadete"].ToString(),
                            Direccion = reader["direccionCadete"].ToString(),
                            Telefono = reader["telefonoCadete"].ToString()
                        };
                    }
                }
                connection.Close();
            }
            return CadeteLeido;
        }

        public void SaveCadete(Cadete Cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"INSERT INTO Cadetes (nombreCadete,direccionCadete,telefonoCadete) VALUES (@nombreCadete,@direccionCadete,@telefonoCadete);";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombreCadete", Cadete.Nombre);
                    command.Parameters.AddWithValue("@direccionCadete", Cadete.Direccion);
                    command.Parameters.AddWithValue("@telefonoCadete", Cadete.Telefono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DesactivarCadete(int Id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"UPDATE Cadetes SET Activo = 0 WHERE CadeteID = {Id}";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    int AffectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarCadete(int Id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"DELETE FROM Cadetes WHERE CadeteID = {Id}";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    int AffectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void EditarCadete(Cadete Cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"UPDATE Cadetes SET nombreCadete = @nombreCadete, direccionCadete = @direccionCadete, telefonoCadete = @telefonoCadete WHERE CadeteID = @CadeteID;";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@CadeteID", Cadete.Id);
                    command.Parameters.AddWithValue("@nombreCadete", Cadete.Nombre);
                    command.Parameters.AddWithValue("@direccionCadete", Cadete.Direccion);
                    command.Parameters.AddWithValue("@telefonoCadete", Cadete.Telefono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

    }

}
