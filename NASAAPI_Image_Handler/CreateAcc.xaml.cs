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
    /// Interaktionslogik für CreateAcc.xaml
    /// </summary>
    public partial class CreateAcc : Window
    {
        public CreateAcc()
        {
            InitializeComponent();
        }

        private void btnCreateQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btnCreateAcc_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn;
            try
            {
                string connString = SecretsCLS.returnSecrets(); //remove the part behind the = with your own connection string!
                conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO Accounts VALUES('" + txtUNameCreate.Text + "', '" + txtUmailCreate.Text + "', '" + txtUPWCreate.Text + "')", conn);
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                AccCreatedPopup wnd = new AccCreatedPopup();
                wnd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { this.Close(); }   
        }
    }
}
