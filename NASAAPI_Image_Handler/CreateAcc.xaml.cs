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
using System.Windows.Shapes;

namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für CreateAcc.xaml
    /// </summary>
    public partial class CreateAcc : Window
    {
        public CreateAcc()
        {
            InitializeComponent();
        }

        private void btnCreateQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateAcc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Soon you will be able to create an Account by Clicking this Button!");
        }
    }
}
