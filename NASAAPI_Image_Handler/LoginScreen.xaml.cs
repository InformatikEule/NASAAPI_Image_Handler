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
using System.Xml.Linq;

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
                try
                {
                    string sql = "SELECT COUNT(1) FROM Accounts WHERE account_name=@uName AND account_password=@pw";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@uName", txtUName.Text },
                        { "@pw", txtPW.Password }
                    };

                    using (var db = new clsMySql())
                    {
                        db.Open();

                        object result = db.ExecuteScalar(sql, parameters);
                        int count = Convert.ToInt32(result);

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
                    }
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
