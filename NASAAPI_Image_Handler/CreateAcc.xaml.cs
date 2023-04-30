using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für CreateAcc2.xaml
    /// </summary>
    public partial class CreateAcc : Window
    {
        public CreateAcc()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn;
            try
            {
                //TODO : Connection already closed when being relocated from the createAcc Page
                //clsSql sql = new clsSql();
                //sql.OpenSqlConnection();
                string connString = clsSecrets.returnSecrets();
                conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO Accounts VALUES('" + txtUName.Text + "', '" + txtUMail.Text + "', '" + txtPW.Password + "')", conn);
                //sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.Connection.Close();
                conn.Close();
                Popup wnd = new Popup();
                wnd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { this.Close(); }
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
