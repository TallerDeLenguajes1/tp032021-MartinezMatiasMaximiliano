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

        public bool ValidarUsuario(Usuario Usuario)
        {
            bool validado = false;

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQueryUsuario = "SELECT * FROM Usuarios where username = @Username AND password = @Password";

                using (SQLiteCommand command = new SQLiteCommand(SQLQueryUsuario, connection))
                {
                    command.Parameters.AddWithValue("@Username", Usuario.Username);
                    command.Parameters.AddWithValue("@Password", Usuario.Password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            validado = true;
                        }
                    }
                    connection.Close();
                }
                return validado;
            }
        }

        public Usuario GetUsuario(Usuario Usuario)
        {
            Usuario result = new Usuario();
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQueryUsuario = "SELECT * FROM Usuarios where username = @Username AND password = @Password";

                using (SQLiteCommand command = new SQLiteCommand(SQLQueryUsuario, connection))
                {
                    command.Parameters.AddWithValue("@Username", Usuario.Username);
                    command.Parameters.AddWithValue("@Password", Usuario.Password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        result.ID = Convert.ToInt32(reader["usuarioID"]);
                        result.Username = reader["username"].ToString();
                        result.Password = reader["password"].ToString();
                        result.Rol = (Rol)Convert.ToInt32(reader["rol"]);
                    }
                    connection.Close();
                }
            }
            return result;
        }

        public bool SaveUsuario(Usuario Usuario)
        {
            bool success = false;
            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQuery = "INSERT INTO Usuarios (username,password,rol) VALUES (@Username,@Password,@rol)";
                using (SQLiteCommand command = new SQLiteCommand(SQLQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", Usuario.Username);
                    command.Parameters.AddWithValue("@Password", Usuario.Password);
                    command.Parameters.AddWithValue("@rol", Convert.ToInt32(Usuario.Rol));
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

        public int GetIDUsuario(Usuario Usuario)
        {
            int resul = -1;

            using (SQLiteConnection connection = new SQLiteConnection(StringDeConexion))
            {
                connection.Open();
                string SQLQueryUsuario = "SELECT * FROM Usuarios where username = @Username AND password = @Password";

                using (SQLiteCommand command = new SQLiteCommand(SQLQueryUsuario, connection))
                {
                    command.Parameters.AddWithValue("@Username", Usuario.Username);
                    command.Parameters.AddWithValue("@Password", Usuario.Password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        resul = Convert.ToInt32(reader["usuarioID"]);
                    }
                    connection.Close();
                }
                return resul;
            }
        }
    }
}
