using MySql.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
using System.Xml;
using System.Xml.Linq;
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


        //next level man. thx stack-overflow! ;D
        //bool IsValidEmail(string email)
        //{
        //    var trimmedEmail = email.Trim();

        //    if (trimmedEmail.EndsWith("."))
        //    {
        //        return false; // suggested by @TK-421
        //    }
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == trimmedEmail;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string sql = $"INSERT INTO accounts VALUES('' ,'{txtUName.Text}', '{txtPW.Password}', '{txtUMail.Text}')";
                
                using (var db = new clsMySql())
                {
                    db.Open();
                    int count = db.ExecuteNonQuery(sql);
                    if (count >= 1)
                    { 
                        Popup Pu = new Popup();
                        Pu.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Something went wrong. Please try again.");
                }
            }
            catch (Exception ex)
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
