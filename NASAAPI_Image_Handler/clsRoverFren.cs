using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NASAAPI_Image_Handler
{
    public class clsRoverFren
    {
        public static async Task LoadRover()
        {
            string url = "";
            //string bspUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=DEMO_KEY";
            url = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=DEMO_KEY";
            
            using (HttpResponseMessage resp = await clsApiFren.ApiClient.GetAsync(url))
            {
                if (resp.IsSuccessStatusCode)
                {
                    clsRoverModel rover = await resp.Content.ReadAsAsync<clsRoverModel>();

                    //return rover;
                }
                else
                {
                    throw new Exception(resp.ReasonPhrase);
                }
            }
        }

    }
}
