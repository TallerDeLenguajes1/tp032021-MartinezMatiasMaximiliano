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

                using (SQLiteCommand command = new SQLiteCommand(SQLQueryUsuario,connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        exists = reader.HasRows;
                    }
                }
                connection.Close();
            }
            return exists;
        }

        public void AltaUsuario()
        {
            throw new NotImplementedException();
        }

        public void BorrarUsuario()
        {
            throw new NotImplementedException();
        }

        public void DesactivarUsuario()
        {
            throw new NotImplementedException();
        }

        public void ModificarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
