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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPercy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can see all pictures from the Perceverance Mars-Rover here soon!");
        }

        private void btnCuriosity_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can see all pictures from the Curiosity Mars-Rover here soon!");
        }

        private void btnSpirit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can see all pictures from the Spirit Mars-Rover here soon!");
        }
    }
}
