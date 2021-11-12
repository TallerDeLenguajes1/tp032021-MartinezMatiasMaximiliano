using Cadeteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Entities
{
    public class SQLiteUsuario : IRepositorioUsuario
    {
        private readonly string StringDeConexion;
        public SQLiteUsuario(string ConnectionString)
        {
            this.StringDeConexion = ConnectionString;
        }

        public bool UsuarioExiste(string Username, string Password)
        {
            bool exists = false;

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQueryUsuario = "SELECT * FROM Usuarios where Username = @Username AND Password = @Password";

                using (SQLiteCommand command = new SQLiteCommand(SQLQueryUsuario, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        exists = reader.HasRows;
                    }
                }
                connection.Close();
            }
            return exists;
        }

        public bool AltaUsuario(string Username, string Password)
        {
            bool success = false;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = "INSERT INTO Usuarios (Username,Password) VALUES (@Username,@Password)";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    int AffectedRows = command.ExecuteNonQuery();

                    if (AffectedRows != 0)
                    {
                        success = true;
                    }
                }
                connection.Close();
            }
            return success;
        }


        public bool DesactivarUsuario(int ID)
        {
            bool success = false;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = "UPDATE Usuarios SET Activo = 0 WHERE IDusuario = @IDusuario";

                using(SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@IDusuario",ID);
                    int AffectedRows = command.ExecuteNonQuery();

                    if (AffectedRows != 0)
                    {
                        success = true;
                    }
                }
                connection.Close();
            }
            return success;
        }

        public bool BorrarUsuario(int ID)
        {
            bool success = false;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = "DELETE FROM Usuarios WHERE IDusuario = @IDusuario";

                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@IDusuario", ID);
                    int AffectedRows = command.ExecuteNonQuery();

                    if (AffectedRows != 0)
                    {
                        success = true;
                    }
                }
                connection.Close();
            }
            return success;
        }

        public void ModificarUsuario()
        {
            
        }
    }
}
