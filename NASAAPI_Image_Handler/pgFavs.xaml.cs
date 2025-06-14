﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static NASAAPI_Image_Handler.clsUserData;

namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für pgFavs.xaml
    /// </summary>
    public partial class pgFavs : Page
    {
        public pgFavs()
        {
            InitializeComponent();
        }

        private void btnPic_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn;
            try
            {
                //CREATE TABLE accounts (ID Int, account_name VARCHAR (255), account_password VARCHAR (255), account_mail VARCHAR (255), account_pic VARCHAR (50));
                string server = "localhost";
                string db = "test";
                string user = "root";
                string pw = "";
                //string connString = clsMySql.returnSecrets();
                string connString = string.Format("server={0};database={1};user={2};password={3};", server, db, user, pw);
                conn = new MySqlConnection(connString);
                Console.WriteLine(conn);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(1) FROM favs WHERE pic=@txtPic", conn);

                cmd.Parameters.AddWithValue("@txtPic", txtPic.Text);
                //cmd.Parameters.AddWithValue("@txtPW", txtPW.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count >= 1)
                {
                    //imgFavs.Source = 
                }
                else
                {
                    MessageBox.Show("Picture not found!");
                }
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void btnShowFavs_Click(object sender, RoutedEventArgs e)
        {
            //GetCache
            //object value = LoadUserFromDatabase( );
            //MessageBox.Show(_cached);
           
        }

        ////////////////////////////////////
        ///
        public class User
        {
            public int ID { get; set; }
            public string? Username { get; set; }
            public string? Usermail { get; set; }
        }

        public class UserService
        {
            private User? _cachedUser;

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
                MessageBox.Show(reader.ToString());
            }
            public string GetCachedUsername()
            {
                return _cachedUser?.Username ?? "[unbekannt]";
            }

        }
        ////////////////////////////////////
        ///Stackoverflow:
        ///
        public static void FillUserListClass()
        {
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", userId);
            ///
            Dictionary<string, User> UserList = new Dictionary<string, User>();
            OleDbConnection conn = new OleDbConnection(strAccessConn);
            string query = "SELECT ControlNumber, UserName FROM Log WHERE Log.EndStatus in ('Needs Review', 'Check Search', 'Vision Delivery', 'CA Review', '1TSI To Be Delivered');";

            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();

            try
            {
                adapter.Fill(dt);

                for (int ctr = 1; ctr <= dt.Rows.Count; ctr++)
                {
                    var row = dt.Rows[ctr];
                    var userName = row["UserName"].ToString();
                    if (!UserList.ContainsKey(userName))
                    {
                        UserList.Add(userName, new User()
                        {
                            UserName = userName,
                            ControlNumber = new List<int>()
                        });
                    }
                    UserList[userName].ControlNumber.Add((int)row["ControlNumber"]);
                }
            }
            catch (OleDbException ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
