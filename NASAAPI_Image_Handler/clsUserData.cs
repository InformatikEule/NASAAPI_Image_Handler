using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NASAAPI_Image_Handler
{
    class clsUserData
    {

        public class User
        {
                public int ID { get; set; }
                public string ?Username { get; set; }
                public string ?Usermail{ get; set; }
        }

        public class UserService
        {
            private User ?_cachedUser;

            public void LoadUserFromDatabase(int userId)
            {
                string connString = "server=localhost;user=root;database=test;password=;";
                var conn = new MySqlConnection(connString);
                conn.Open();

                string query = "SELECT ID, account_name, account_mail FROM accounts WHERE ID = @id";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                var reader = cmd.ExecuteReader();
                MessageBox.Show(reader.ToString());
                if (reader.Read())
                {
                    _cachedUser = new User
                    {
                        ID = reader.GetInt32("ID"),
                        Username = reader.GetString("Username"),
                        Usermail = reader.GetString("Usermail")
                    };
                }
            }

            public string GetCachedUsername()
            {
                return _cachedUser?.Username ?? "[unbekannt]";
            }
        }
    }
}
