using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Entities
{
    public class SQLiteCliente : IRepositorioCliente
    {
        private readonly string StringDeConexion;

        public SQLiteCliente(string _ConnectionString)
        {
            StringDeConexion = _ConnectionString;
        }

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = "SELECT * FROM Clientes WHERE activo = 1";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente Cliente = new Cliente()
                            {
                                Id = Convert.ToInt32(reader["clienteID"]),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString()
                            };
                            listaClientes.Add(Cliente);
                        }
                    }
                }
                connection.Close();
            }
            return listaClientes;
        }

        public Cliente GetClienteByID(int ID)
        {
            Cliente ClienteLeido = null;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = $"SELECT * FROM Clientes WHERE clienteID = @clienteID";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@clienteID",ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) {
                            ClienteLeido = new Cliente()
                            {
                                Id = Convert.ToInt32(reader["clienteID"]),
                                UsuarioID = Convert.ToInt32(reader["usuarioID"]),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString()
                            };
                        }
                        
                    }
                }
                connection.Close();
            }
            return ClienteLeido;
        }

        public void SaveCliente(Cliente Cliente)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"INSERT INTO Clientes (nombre,direccion,telefono) VALUES (@nombreCliente,@direccionCliente,@telefonoCliente)";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombreCliente", Cliente.Nombre);
                    command.Parameters.AddWithValue("@direccionCliente", Cliente.Direccion);
                    command.Parameters.AddWithValue("@telefonoCliente", Cliente.Telefono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DesactivarCliente(int Id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"UPDATE Clientes SET activo = 0 WHERE clienteID = @clienteID";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@clienteID", Id);
                    int AffectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarCliente(int Id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"DELETE FROM Clientes where usuarioID = @IDcliente";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@IDcliente", Id);
                    int AffectedRows = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ModificarCliente(Cliente Cliente)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"UPDATE Clientes SET nombre = @nombreCliente, direccion = @direccionCliente, telefono = @telefonoCliente WHERE clienteID = @ClienteID;";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClienteID", Cliente.Id);
                    command.Parameters.AddWithValue("@nombreCliente", Cliente.Nombre);
                    command.Parameters.AddWithValue("@direccionCliente", Cliente.Direccion);
                    command.Parameters.AddWithValue("@telefonoCliente", Cliente.Telefono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public int GetClienteID(int ID)
        {
            int clienteID = -1;

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = "SELECT clienteID FROM Clientes WHERE usuarioID = @usuarioID ";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@usuarioID", ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        clienteID = Convert.ToInt32(reader["clienteID"]);
                    }
                }
                connection.Close();
            }
                return clienteID;
        }
    }
}
