using System;
using System.Collections.Generic;
using System.Drawing;
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
using static NASAAPI_Image_Handler.clsUserData;

namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für pgAcc.xaml
    /// </summary>
    public partial class pgAcc : Page
    {
        //public User CurrentUser { get; set; }
        public pgAcc()
        {
            InitializeComponent();

            //CurrentUser = new User
            //{
            //    Username = GetCachedUsername(),
            //    Usermail = "max@example.com",
            //    //Password = "geheim123"
            //};

            //DataContext = CurrentUser;
            //PasswordBox.Password = CurrentUser.Password;
            void loadImage()
            {
                //var path = Path.Combine(Environment.CurrentDirectory, "Data", "owl_logo.jpg");
                //var uri = new Uri(path);
                //image1.Source = bitmap;
            }
        }
    }
}
