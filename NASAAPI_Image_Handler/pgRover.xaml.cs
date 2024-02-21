using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using static NASAAPI_Image_Handler.pgApod;

namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für pgRover.xaml
    /// </summary>
    public partial class pgRover : Page
    {
        public pgRover()
        {
            InitializeComponent();
        }

        private async Task LoadRover()
        {

        }

        public class RoverData
        {
            public string? rover { get; set; }
            public string? img_src { get; set; }
            public string? camera{ get; set; }
        }

        private async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                var resp = await client.GetAsync("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=DEMO_KEY");
                resp.EnsureSuccessStatusCode();
                if (resp.IsSuccessStatusCode)
                {
                    var content = await resp.Content.ReadAsStringAsync();
                    var roverData = JsonConvert.DeserializeObject<RoverData>(content);
                    txtRoverName.Text = roverData?.rover;
                }
                else
                {
                    MessageBox.Show("Error: " + resp.StatusCode);
                }
            }
        }


        private void btnPercFav_Click(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bald!");
        }
    }
}
