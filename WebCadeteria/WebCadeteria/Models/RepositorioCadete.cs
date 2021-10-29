using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using WebCadeteria.Entities;

namespace WebCadeteria.Models
{
    public class RepositorioCadete
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioCadete(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        #region Lectura
        public List<Cadete> getAll()
        {
            List<Cadete> listaCadetes = new List<Cadete>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = "select * from Cadetes;";
                using (SQLiteCommand comando = new SQLiteCommand(SQLQuery, conexion))
                {
                    SQLiteDataReader reader = comando.ExecuteReader();


                    while (reader.Read())
                    {
                        Cadete CadeteLeido = new Cadete() {
                            Id = Convert.ToInt32(reader["cadeteID"]),
                            Nombre = reader["cadeteNombre"].ToString(),
                            Direccion = reader["cadeteDireccion"].ToString(),
                            Telefono = reader["cadeteTelefono"].ToString()
                        };
                        listaCadetes.Add(CadeteLeido);
                    }
                }

                conexion.Close();
                return listaCadetes;
            }
        }
        #endregion

        #region Alta
        public void AltaCadete(Cadete nuevoCadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = $"insert into Cadetes (cadeteID,cadeteNombre,cadeteDireccion,cadeteriaId)values {nuevoCadete.Id},{nuevoCadete.Nombre},{nuevoCadete.Direccion},{1})";
                using (SQLiteCommand comando = new SQLiteCommand(SQLQuery, conexion))
                {
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        #endregion

        #region Baja
        public void BajaCadete(Cadete Cadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = $"delete from Cadetes where cadeteID = {Cadete.Id}";
                using (SQLiteCommand comando = new SQLiteCommand(SQLQuery, conexion))
                {
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        #endregion

        #region Modificacion
        public void ModificarCadete(Cadete Cadete)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery = $"update Cadetes set cadeteID = {Cadete.Id}, cadeteNombre = {Cadete.Nombre}, cadeteTelefono = {Cadete.Telefono}";
                using (SQLiteCommand comando = new SQLiteCommand(SQLQuery, conexion))
                {
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
        #endregion

    }

}