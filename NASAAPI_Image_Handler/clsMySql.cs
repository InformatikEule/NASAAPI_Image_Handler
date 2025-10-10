using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NASAAPI_Image_Handler
{
    public class clsMySql : IDisposable
    {
        private readonly MySqlConnection _connection;
        public clsMySql()
        {
            string server = "localhost";
            string db = "test";
            string user = "root";
            string pw = "";
            string connString = $"server={server};database={db};user={user};password={pw};";
            _connection = new MySqlConnection(connString);
        }

        public void Open()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
        }

        public void Close()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
        }

        /// <summary>
        /// Gibt keine Daten zur�ck (INSERT, UPDATE, DELETE)
        /// </summary>
        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            using (var cmd = new MySqlCommand(sql, _connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gibt Daten zur�ck (SELECT)
        /// </summary>
        public MySqlDataReader ExecuteReader(string sql, Dictionary<string, object> parameters = null)
        {
            var cmd = new MySqlCommand(sql, _connection);

            if (parameters != null)
            {
                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            // kein "using" hier, da der Reader die Verbindung offen halten muss
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// Gibt bestimmte Menge an Daten zur�ck (SELECT COUNT()) (einzelner Wert)
        /// </summary>
        public object ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            using (var cmd = new MySqlCommand(sql, _connection))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                return cmd.ExecuteScalar();
            }
        }

        public void Dispose()
        {
            Close();
            _connection.Dispose();
        }
    }
}