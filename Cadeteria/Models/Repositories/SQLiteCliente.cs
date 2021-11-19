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
                string SQLQuery = "SELECT * FROM Clientes WHERE Activo = 1";

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
                string SQLQuery = $"SELECT * FROM Clientes WHERE usuarioID = @usuarioID";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@usuarioID",ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        ClienteLeido = new Cliente()
                        {
                            Id = Convert.ToInt32(reader["ClienteID"]),
                            Nombre = reader["nombreCliente"].ToString(),
                            Direccion = reader["direccionCliente"].ToString(),
                            Telefono = reader["telefonoCliente"].ToString()
                        };
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
                string SQLQuery = $"INSERT INTO Clientes (nombre,direccion,telefono,usuarioID) VALUES (@nombreCliente,@direccionCliente,@telefonoCliente,@usuarioID)";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombreCliente", Cliente.Nombre);
                    command.Parameters.AddWithValue("@direccionCliente", Cliente.Direccion);
                    command.Parameters.AddWithValue("@telefonoCliente", Cliente.Telefono);
                    command.Parameters.AddWithValue("@usuarioID", Cliente.UsuarioID);
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
                string SQLQuery = $"UPDATE Clientes set Activo = 0 where usuarioID = @usuarioID";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@usuarioID", Id);
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
    }
}
