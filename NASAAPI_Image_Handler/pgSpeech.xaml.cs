using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
namespace NASAAPI_Image_Handler
{
    /// <summary>
    /// Interaktionslogik für pgSpeech.xaml
    /// </summary>
    public partial class pgSpeech : Page
    {
        private SpeechSynthesizer synthesizer;

        public pgSpeech()
        {
            InitializeComponent();
            synthesizer = new SpeechSynthesizer();
        }

        private void BtnSpeakText_Click(object sender, RoutedEventArgs e)
        {
            string text = InputTextBox.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {
                synthesizer.SpeakAsync(text);
            }
            else
            {
                MessageBox.Show("Bitte gib einen Text ein.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnSpeakDateTime_Click(object sender, RoutedEventArgs e)
        {
            string timeInfo = $"Es ist {DateTime.Now.ToString("T", CultureInfo.InvariantCulture)} am {DateTime.Now.ToString("D", new CultureInfo("de-DE"))}";
            //string timeInfo = $"It is {DateTime.Now.ToLongTimeString()} on {DateTime.Now.ToLongDateString()}";
            synthesizer.SpeakAsync(timeInfo);
        }

        private void RBMetLines_Checked(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(LanguageGer.IsChecked))
            {
                var language = new CultureInfo("de-DE");
            }else
            {
                var language = new CultureInfo("en-EN");
            }
        }
    }
}
