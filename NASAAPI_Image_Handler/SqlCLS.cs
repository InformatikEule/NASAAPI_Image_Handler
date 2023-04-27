using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NASAAPI_Image_Handler
{
    class SqlCLS
    {
        public static SqlConnection conn;
        public void OpenSqlConnection()
        {
            try
            {



                string connString = SecretsCLS.returnSecrets();
                conn = new SqlConnection(connString);
                conn.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show("Error opening SQL Connection: " + e);
            }

        }

        public void LoginSql()
        {
            //SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Accounts WHERE UName=@txtUName AND UPW=@txtPW", conn);

            //cmd.Parameters.AddWithValue("@txtUName", txtUName.Text);
            //cmd.Parameters.AddWithValue("@txtPW", txtPW.Password);

            //int count = Convert.ToInt32(cmd.ExecuteScalar());
            //if (count >= 1)
            //{
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();
            //    //this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Wrong Username, Password or E-Mail!");
            //}
            //conn.Close();
        }
    }
}
