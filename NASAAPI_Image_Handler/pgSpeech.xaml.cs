using System;
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
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        }

        private void btnTalk_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.SpeakAsync("Hallo");
        }
    }

}
