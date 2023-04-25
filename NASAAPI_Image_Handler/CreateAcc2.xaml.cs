﻿using System;
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
    public partial class CreateAcc2 : Window
    {
        public CreateAcc2()
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
                string connString = SecretsCLS.returnSecrets(); //remove the part behind the = with your own connection string!
                conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO Accounts VALUES('" + txtUName.Text + "', '" + txtUMail.Text + "', '" + txtPW.Password + "')", conn);
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
