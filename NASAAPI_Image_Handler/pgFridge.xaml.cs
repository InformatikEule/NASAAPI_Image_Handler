using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            LoadMeals();
        }

        private void btnHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //datum vom deutschen Format ins Amerikanische:
                string dateGerman = datPicked.Text;
                DateTime parsed = DateTime.ParseExact(dateGerman, "dd.MM.yyyy", null);
                string sqlDate = parsed.ToString("yyyy-MM-dd");

                string sql = "INSERT INTO meals (Name, Menge, Datum, Art) VALUES (@name, @menge, @datum, @art)";
                var parameters = new Dictionary<string, object>
                {
                    { "@Name", txtName.Text },
                    { "@Menge", txtMenge.Text },
                    { "@Datum", sqlDate },
                    { "@Art", comBoxArt.Text }
                };

                using var db = new clsMySql();
                db.Open();
                int count = db.ExecuteNonQuery(sql, parameters);

                if (count >= 1)
                {
                    txtName.Clear();
                    txtMenge.Clear();
                    datPicked.SelectedDate = null;
                    comBoxArt.SelectedItem = null;
                    LoadMeals();
                }
                else
                    MessageBox.Show("Etwas ist schiefgelaufen.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Schreiben in die Datenbank:" + ex.Message);
            }
        }

        private void LoadMeals()
        {
            try
            {
                List<clsMeal> meals = new List<clsMeal>();

                using (var db = new clsMySql())
                {
                    db.Open();
                    string sql = "SELECT id, name, menge, datum, art FROM meals";

                    using var reader = db.ExecuteReader(sql);
                    while (reader.Read())
                    {
                        var meal = new clsMeal
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Menge = reader.GetString("menge"),
                            Datum = reader.GetDateTime("datum").ToString("dd.MM.yyyy"),
                            Art = reader.GetString("art")
                        };
                        meals.Add(meal);
                    }
                }
                lvMeals.ItemsSource = meals;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Daten:\n" + ex.Message);
            }
        }
    }
}
