using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für pgFridge.xaml
    /// </summary>
    public partial class pgFridge : Page
    {
        public pgFridge()
        {
            InitializeComponent();
        }

        private void btnHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn;
            try
            {
                string deutschesDatum = "09.10.2025"; // Tag.Monat.Jahr
                DateTime parsed = DateTime.ParseExact(deutschesDatum, "dd.MM.yyyy", null);

                // MySQL braucht "YYYY-MM-DD"
                string mysqlDatum = parsed.ToString("yyyy-MM-dd");

                // Dann mit mysqlDatum in die DB schreiben
                string sql = $"INSERT INTO tabelle (datum) VALUES ('{mysqlDatum}')";



                string server = "localhost";
                string db = "test";
                string user = "root";
                string pw = "";
                string connString = string.Format("server={0};database={1};user={2};password={3};", server, db, user, pw);
                conn = new MySqlConnection(connString);
                conn.Open();
                string dateGerman = datPicked.Text;
                DateTime x = DateTime.ParseExact(dateGerman, "dd.MM.yyyy", null);
                string sqlDate = x.ToString("yyyy-MM-dd");
                MessageBox.Show(sqlDate);
                MySqlCommand sqlCmd = new MySqlCommand("INSERT INTO meals VALUES('' ,'" + txtName.Text + "', '" + txtMenge.Text + "', '" + sqlDate + "', '" + comBoxArt.Text + "')", conn);

                int count = Convert.ToInt32(sqlCmd.ExecuteNonQuery());
                if (count >= 1)
                {
                    MessageBox.Show("Deine Mahlzeit wurde gespeichert!");
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again.");
                }
                sqlCmd.Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing into DB: " + ex.Message);
            }
        }
    }
}
