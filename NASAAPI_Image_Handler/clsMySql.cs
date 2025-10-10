using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls.Crypto;
using System.Data.SqlClient;
using System;
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

        public int ExecuteNonQuery(string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, _connection))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, _connection))
            {
                return cmd.ExecuteReader();
            }
        }

        public void Dispose()
        {
            Close();
            _connection.Dispose();
        }
    }
}