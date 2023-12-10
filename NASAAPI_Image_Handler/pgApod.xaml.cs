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
        public pgApod()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender,  RoutedEventArgs e)
        {
            GetAPOD();
        }

        private async void GetAPOD()
        {
            var resp = await cl.GetAsync("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY");
            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                var apodData = JsonConvert.DeserializeObject<ApodData>(content);
                txtApodTitle.Text = apodData?.title;
                //DateTextBlock.Text = apodData.date;
                txtApodDesc.Text = apodData?.explanation;
                BitmapImage img = new BitmapImage(new Uri(apodData.url));
                PictureImage.Source = img;
            }
            else
            {
                MessageBox.Show($"Failed to retrieve data. Status code: {resp.StatusCode}");
            }
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


