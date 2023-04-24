
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {



            SqlConnection conn;
            try
            {
                string connString = SecretsCLS.returnSecrets();
                conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Accounts WHERE UName=@txtUName AND UMail=@txtMail AND UPW=@txtPW", conn);

                cmd.Parameters.AddWithValue("@txtUName", txtUName.Text);
                cmd.Parameters.AddWithValue("@txtMail", txtMail.Text);
                cmd.Parameters.AddWithValue("@txtPW", txtPW.Text);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Der Username oder das Passwort stimmen nicht.");
                }

                //string connString = SecretsCLS.returnSecrets(); // remove the part behind the = and fill in your own connection string!
                //conn = new SqlConnection(connString);

                //conn.Open();

                //string sqlCmd = "SELECT COUNT(1) FROM Accounts WHERE UName=@txtUName AND UMail=@txtMail AND UPW=@txtPW";
                //SqlCommand cmd = new SqlCommand(sqlCmd, conn);


                //SqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    string rowResult = string.Format("Username: {0}, User Mail: {1}, User Password: {2}",
                //                    reader.GetValue(0), reader.GetValue(1), reader.GetValue(2));
                //    MessageBox.Show(rowResult);
                //    Console.WriteLine(rowResult);
                //}
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
