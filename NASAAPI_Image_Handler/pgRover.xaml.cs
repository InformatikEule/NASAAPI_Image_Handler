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

        private async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {
                var resp = await client.GetAsync("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=DEMO_KEY");
                resp.EnsureSuccessStatusCode();
                if (resp.IsSuccessStatusCode)
                {
                    //var json = await resp.Content.ReadFromJsonAsync();
                    //MessageBox.Show(await resp.Content.ReadAsStringAsync());
                    txtRoverName.Text = await resp.Content.ReadAsStringAsync();
                    //var respCont = await resp.Content.ReadAsStringAsync();
                    //MessageBox.Show(respCont.ToString());
                    //var jsonStringNewtonsoft = JsonConvert.SerializeObject(respCont);
                    //MessageBox.Show(jsonStringNewtonsoft);
                }
                else
                {
                    MessageBox.Show("Error: " + resp.StatusCode);
                }
            }
        }
    }
}
