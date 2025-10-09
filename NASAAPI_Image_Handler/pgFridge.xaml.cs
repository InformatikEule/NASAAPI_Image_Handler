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
    /// Interaktionslogik für pgFridge.xaml
    /// </summary>
    public partial class pgFridge : Page
    {
        public pgFridge()
        {
            InitializeComponent();
        }

        private void btnHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }
    }
}
