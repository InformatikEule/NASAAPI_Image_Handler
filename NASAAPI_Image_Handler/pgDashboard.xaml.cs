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
    /// Interaktionslogik für pgDashboard.xaml
    /// </summary>
    public partial class pgDashboard : Page
    {
        public pgDashboard()
        {
            InitializeComponent();
        }

        private void btnFull_Click(object sender,  RoutedEventArgs e)
        {
            //if (this.PageState == WindowState.Normal)
            //{
            //    this.WindowState = WindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = WindowState.Normal;
            //}
        }
    }
}
