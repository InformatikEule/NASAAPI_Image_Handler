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
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;
using System.Windows.Threading;

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
            SetClock();
            clsApiFren.InitializeClient();
            //only use the workspace of the user-screen when in fullscreen-mode
            //this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnRover_Click(object sender, RoutedEventArgs e)
        {
            pgRover s1 = new pgRover();   
            contentSpace.Content = s1.Content;
            txtPageName.Text = "RoverPage";
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            pgDashboard s2 = new pgDashboard();
            contentSpace.Content = s2.Content;
            txtPageName.Text = "Dashboard";
        }

        private void btnApod_Click(object sender, RoutedEventArgs e)
        {
            pgApod s3 = new pgApod();
            contentSpace.Content = s3.Content;
            txtPageName.Text = "Apod";
        }

        void SetClock()
        {
            DispatcherTimer Dt = new DispatcherTimer();
            Dt.Tick += new EventHandler(Dt_Tick);
            Dt.Interval = new TimeSpan(0, 0, 1);
            Dt.Start();
        }
        void Dt_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToLongDateString();//("dd:MM:yy");
            txtTime.Text = DateTime.Now.ToShortTimeString();//("HH:mm:ss");
        }
    }
}
