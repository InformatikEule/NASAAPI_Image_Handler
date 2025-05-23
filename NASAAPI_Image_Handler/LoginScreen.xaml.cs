using MySql.Data.MySqlClient;
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
            if (String.IsNullOrEmpty(txtUName.Text) && String.IsNullOrEmpty(txtPW.Password))
            {
                MessageBox.Show("You forgot something...");
            }
            else
            {
                MySqlConnection conn;
                try
                {
                    string server = "localhost";
                    string db = "test";
                    string user = "root";
                    string pw = "";
                    //string connString = clsMySql.returnSecrets();
                    string connString = string.Format("server={0};database={1};user={2};password={3};", server, db, user, pw);
                    conn = new MySqlConnection(connString);
                    Console.WriteLine(conn);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(1) FROM Accounts WHERE USERNAME=@txtUName AND PASSWORD=@txtPW", conn);

                    cmd.Parameters.AddWithValue("@txtUName", txtUName.Text);
                    cmd.Parameters.AddWithValue("@txtPW", txtPW.Password);
                    //cmd.Connection = clsSql.conn;

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count >= 1)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username, Password or E-Mail!");
                    }
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCreateAcc_Click(object sender, RoutedEventArgs e)
        {
            CreateAcc wndCreateAcc = new CreateAcc();
            wndCreateAcc.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
