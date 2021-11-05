using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Entities
{
    public interface IRepositorioCadete
    {
        void BorrarCadete(int Id);
        void DesactivarCadete(int Id);
        void EditarCadete(Cadete Cadete);
        List<Cadete> GetAllCadetes();
        Cadete GetCadeteById(int ID);
        void SaveCadete(Cadete Cadete);
    }

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
                string SQLQuery = "SELECT * FROM Cadetes WHERE Activo = 1";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cadete cadeteleido = new Cadete()
                            {
                                Id = Convert.ToInt32(reader["CadeteID"]),
                                Nombre = reader["nombreCadete"].ToString(),
                                Direccion = reader["direccionCadete"].ToString(),
                                Telefono = reader["telefonoCadete"].ToString()
                            };
                            listaCadetes.Add(cadeteleido);
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
                string SQLQuery = $"SELECT * FROM Cadetes WHERE CadeteID = {ID}";

                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
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
                string SQLQuery = $"INSERT INTO Cadetes (nombreCadete,direccionCadete,telefonoCadete,vehiculoCadete) VALUES (@nombreCadete,@direccionCadete,@telefonoCadete,@vehiculoCadete);";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombreCadete", Cadete.Nombre);
                    command.Parameters.AddWithValue("@direccionCadete", Cadete.Direccion);
                    command.Parameters.AddWithValue("@telefonoCadete", Cadete.Telefono);
                    command.Parameters.AddWithValue("@vehiculoCadete", Cadete.Vehiculo);
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
