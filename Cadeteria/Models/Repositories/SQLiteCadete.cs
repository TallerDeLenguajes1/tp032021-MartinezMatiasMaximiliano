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
                string SQLQueryCadetes = "SELECT * FROM Cadetes WHERE activo = 1";
                connection.Open();

                using (SQLiteCommand LeerCadetes = new SQLiteCommand(SQLQueryCadetes, connection))
                {
                    using (SQLiteDataReader cadetesLeidos = LeerCadetes.ExecuteReader())
                    {
                        while (cadetesLeidos.Read())
                        {
                            Cadete Cadete = new Cadete()
                            {
                                Id = Convert.ToInt32(cadetesLeidos["cadeteID"]),
                                Nombre = cadetesLeidos["nombre"].ToString(),
                                Direccion = cadetesLeidos["direccion"].ToString(),
                                Telefono = cadetesLeidos["telefono"].ToString(),
                                ListaPedidos = new SQLitePedido(StringDeConexion).GetAllPedidosDeCadete(Convert.ToInt32(cadetesLeidos["cadeteID"]))
                            };
                            listaCadetes.Add(Cadete);
                        }
                    }
                }
                connection.Close();
            }
            return listaCadetes;
        }

        public Cadete GetCadeteByID(int ID)
        {
            Cadete CadeteLeido = null;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = $"SELECT * FROM Cadetes WHERE cadeteID = @cadeteID";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@cadeteID", ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        CadeteLeido = new Cadete()
                        {
                            Id = Convert.ToInt32(reader["cadeteID"]),
                            UsuarioID = Convert.ToInt32(reader["usuarioID"]),
                            Nombre = reader["nombre"].ToString(),
                            Direccion = reader["direccion"].ToString(),
                            Telefono = reader["telefono"].ToString()
                        };
                    }
                }
                connection.Close();
            }
            return CadeteLeido;
        }

        public int GetCadeteID(int ID){
            int result = -1;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                string SQLQuery = $"SELECT * FROM Cadetes WHERE usuarioID = @usuarioID";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@usuarioID", ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        
                        result = Convert.ToInt32(reader["cadeteID"]);
                            
                    }
                }
                connection.Close();
            }
            return result;
        }
        public void SaveCadete(Cadete Cadete)
        {
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = $"INSERT INTO Cadetes (nombre,direccion,telefono,usuarioID) VALUES (@nombreCadete,@direccionCadete,@telefonoCadete,@usuarioID);";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombreCadete", Cadete.Nombre);
                    command.Parameters.AddWithValue("@direccionCadete", Cadete.Direccion);
                    command.Parameters.AddWithValue("@telefonoCadete", Cadete.Telefono);
                    command.Parameters.AddWithValue("@usuarioID", Cadete.UsuarioID);
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
                string SQLQuery = $"UPDATE Cadetes SET activo = 0 WHERE cadeteID = @cadeteID";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@cadeteID", Id);
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
                string SQLQuery = $"DELETE FROM Cadetes WHERE cadeteID = @IDcadete";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@IDcadete", Id);
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
                string SQLQuery = $"UPDATE Cadetes SET nombre = @nombreCadete, direccion = @direccionCadete, telefono = @telefonoCadete WHERE cadeteID = @cadeteID;";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@cadeteID", Cadete.Id);
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
