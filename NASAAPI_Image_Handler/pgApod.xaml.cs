using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaktionslogik für pgApod.xaml
    /// </summary>
    public partial class pgApod : Page
    {
        static readonly HttpClient cl = new HttpClient();
        string comparedDate;

        public pgApod()
        {
            InitializeComponent();
        }   

        public string compareDate()
        {
            var today = DateTime.Today;
            var pickedDate = dateApod?.SelectedDate;
            var comparedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];    //dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            //var today = DateTime.Today.ToString("yyyy-MM-dd").Split(' ')[0];
            //var pickedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            if (pickedDate < today)
            {
                GetAPOD(comparedDate);
                return comparedDate;
            }
            else
            {
                return "";
            }
        }

        private async void GetAPOD(string comparedDate)
        {
            compareDate();
            var resp = await cl.GetAsync($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={comparedDate}");
            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                var apodData = JsonConvert.DeserializeObject<ApodData>(content);
                txtApodTitle.Text = apodData?.title;
                //datetextblock.text = apoddata.date;
                txtApodDesc.Text = apodData?.explanation;
                BitmapImage img = new BitmapImage(new Uri(apodData.url));
                PictureImage.Source = img;
            }
            else
            {
                MessageBox.Show($"failed to retrieve data. status code: {resp.StatusCode}");
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            GetAPOD(comparedDate);
            //var pickedDateTest = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            //var respTest = ($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={pickedDateTest}asd");
            //MessageBox.Show("Test hier: " + respTest);
        }

        private void btnSaveFav_Click(Object sender, RoutedEventArgs e)
        {
            var today = DateTime.Today;
            var pickedDate = dateApod?.SelectedDate;
            var comparedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];    //dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            MessageBox.Show("today: " + today);
            MessageBox.Show("comp: " + comparedDate);
            //MessageBox.Show("Hier kannst du deine Lieblingsbilder bald speichern!");
        }

        public class ApodData
        {
            public string? title { get; set; }
            public string? date { get; set; }
            public string? explanation { get; set; }
            public string? url { get; set; }
        }
    }
}


