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
            try
            {
                //datum vom deutschen Format ins Amerikanische:
                string dateGerman = datPicked.Text;
                DateTime parsed = DateTime.ParseExact(dateGerman, "dd.MM.yyyy", null);
                string sqlDate = parsed.ToString("yyyy-MM-dd");
                string sql = "INSERT INTO meals (name, menge, datum, art) VALUES (@name, @menge, @datum, @art)";

                var parameters = new Dictionary<string, object>
                {
                    { "@name", txtName.Text },
                    { "@menge", txtMenge.Text },
                    { "@datum", sqlDate },
                    { "@art", comBoxArt.Text }
                };

                using (var db = new clsMySql())
                {
                    db.Open();
                    int count = db.ExecuteNonQuery(sql, parameters);

                    if (count >= 1)
                        MessageBox.Show("Deine Mahlzeit wurde gespeichert!");
                    else
                        MessageBox.Show("Etwas ist schiefgelaufen.");
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Fehler beim Schreiben in die Datenbank:" + ex.Message);
            }
        }
    }
}
