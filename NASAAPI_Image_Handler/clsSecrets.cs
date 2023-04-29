using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace NASAAPI_Image_Handler
{
    public class clsSecrets
    {
        public static string returnSecrets()
        {
            string DBConnector = @"Server=DESKTOP-OI0MPB4\SQLEXPRESS;Database=NasaAPI_Image_Handler;user=felix;password=;Trusted_Connection=True;";
            return DBConnector;
        }
        
    }
}
