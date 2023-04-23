
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public string uName = "f";
        public string uMail = "mail@mail.de";
        public string uPw = "123";
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {



        SqlConnection conn;
            try
            {
                    //            SqlConnection conn = new SqlConnection(
                    //    "Server=" + host + ";Database=" + db + ";user=" + usr + ";password=" + pw + ";"
                    //);

                string connString = @"Server=localhost;Database=NasaAPI_Image_Handler;user=;password="; // User ID=Admin; Password=Root
                conn = new SqlConnection(connString);

                conn.Open();

                string sql = "Select UName, UMail, UPW from Accounts";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string rowResult = string.Format("Username: {0}, User Mail: {1}, User Password: {2}",
                                    reader.GetValue(0), reader.GetValue(1), reader.GetValue(2));

                    Console.WriteLine(rowResult);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FEHLER HIER: " + ex);
            }



            //if (txtBoxUName.Text == uName && txtMail.Text == uMail && txtPW.Text == uPw)
            //{
            //    MainWindow wndMain = new MainWindow();
            //    wndMain.Show();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Wrong Username, Password or E-Mail!");
            //}

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateAccL_Click(object sender, RoutedEventArgs e)
        {
            CreateAcc wndCreateAcc = new CreateAcc();
            wndCreateAcc.Show();
            this.Close();
        }
    }
}
