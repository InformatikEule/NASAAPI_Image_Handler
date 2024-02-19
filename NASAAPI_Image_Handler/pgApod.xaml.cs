using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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

        //public string compareDate()
        //{
        //    var today = DateTime.Today;
        //    var td2 = today.Date;
        //    var todayChanged = today.ToString("yyyy-MM-dd").Split(' ')[0];
        //    var pickedDate = dateApod?.SelectedDate;
        //    //var p2 = pickedDate.
        //    var comparedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];    //dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
        //    //var today = DateTime.Today.ToString("yyyy-MM-dd").Split(' ')[0];
        //    //var pickedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
        //    if (pickedDate > today)
        //    {
        //        return "";

        //    }
        //    else
        //    {
        //        GetAPOD(comparedDate);
        //        return comparedDate;
        //    }
        //}
        string apodURL;
        private async void GetAPOD()
        {
            
            var resp = await cl.GetAsync("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY");
            //var pickedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            //var resp = await cl.GetAsync($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={pickedDate}");
            if (resp.IsSuccessStatusCode)
            {
                MessageBox.Show("resp hier :" + resp);
                var content = await resp.Content.ReadAsStringAsync();
                var apodData = JsonConvert.DeserializeObject<ApodData>(content);
                txtApodTitle.Text = apodData?.title;
                //DateTextBlock.Text = apodData.date;
                //datetextblock.text = apoddata.date;
                txtApodDesc.Text = apodData?.explanation;
                BitmapImage img = new BitmapImage(new Uri(apodData.url));
                string apodURL = apodData.url;
                MessageBox.Show(apodURL);
                PictureImage.Source = img;
            }
            else
            {
                MessageBox.Show($"Failed to retrieve data. Status code: {resp.StatusCode}");
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            GetAPOD();
            //var pickedDateTest = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            //var respTest = ($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={pickedDateTest}asd");
            //MessageBox.Show("Test hier: " + respTest);
        }

        private void btnSaveFav_Click(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hallo" + apodURL);
            //var paramDate = DateTime.ParseExact(DateTime.Today, "yyyy-MM-dd");
            //var today = DateTime.Today;
            //DateTime d = Convert.ToDateTime("yyyy-MM-dd");
            //var todayChanged = today.ToString("yyyy-MM-dd").Split(' ')[0];
            //var pickedDate = dateApod?.SelectedDate;
            //var comparedDate = dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];    //dateApod?.SelectedDate?.ToString("yyyy-MM-dd").Split(' ')[0];
            //var asd = comparedDate.
            //MessageBox.Show("today: " + d);
            //MessageBox.Show("CHANGED: " + pickedDate);
            //MessageBox.Show("comp: " + comparedDate);
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


