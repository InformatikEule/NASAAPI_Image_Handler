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
using System.Xml.Linq;
using System.Xml;
using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            MySqlConnection conn;
            try 
            {
                ////DB ver. 2:
                //-- Tabelle "account"
                //CREATE TABLE account(
//                    id INT AUTO_INCREMENT PRIMARY KEY,
//                    name VARCHAR(255) NOT NULL,
//                    password VARCHAR(255) NOT NULL,
//                    mail VARCHAR(255) NOT NULL UNIQUE
//                );

//                --Tabelle "account_settings"
//CREATE TABLE account_settings(
//    id INT PRIMARY KEY,
//    user_picture VARCHAR(255),
//    FOREIGN KEY(id) REFERENCES account(id) ON DELETE CASCADE
//);

                //INSERT INTO accounts VALUES('', 'F', '123', 'F@web.de', 'owl_logo.jpg')
                string server = "localhost";
                string db = "test";
                string user = "root";
                string pw = "";
                string connString = string.Format("server={0};database={1};user={2};password={3};", server, db, user, pw);
                conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("INSERT INTO accounts VALUES('' ,'" + txtUName.Text + "', '" + txtPW.Password + "', '" + txtUMail.Text + "', '" + txtUPic.Text + "')", conn);

                int count = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (count >= 1)
                {
                    Popup Pu = new Popup();
                    Pu.Show();
                    //MainWindow mainWindow = new MainWindow();
                    //mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again.");
                }
                sqlCmd.Connection.Close();

            } catch (Exception ex)
            {
                MessageBox.Show("Error writing into DB: " + ex.Message);
            }
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
