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
using System.Windows.Threading;

namespace WpfTryGalgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(DispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);

        }
        char[] ZoekWoordArray;
        char[] VerbergWoordArray;
        string woord;
        int Timer;
        int levens;
        StringBuilder JuisteLetters = new StringBuilder();
        StringBuilder FouteLetters = new StringBuilder();
        DispatcherTimer timer = new DispatcherTimer();



       private void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            TxtTekst.Text = "Geheim woord ingeven";
            BtnRaad.IsEnabled = false;
            TxtWoord.Clear();
            BtnVerbergWoord.Visibility = Visibility.Visible;
            JuisteLetters.Clear();
            FouteLetters.Clear();
            levens = 10;
            timer.Stop();
            LblTimer.Visibility = Visibility.Hidden;
            LblMaskingWoord.Visibility = Visibility.Hidden;
            ZoekWoordArray = new char[] { };
            VerbergWoordArray = new char[] { };
            TxtWoord.IsEnabled = true;
            Image();
            MnITimer.Visibility = Visibility.Visible;
            MnITimer.IsEnabled = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTekst.Text = "Geheim woord ingeven";
            BtnRaad.IsEnabled = false;
            levens = 10;
            LblTimer.Visibility = Visibility.Hidden;
            LblMaskingWoord.Visibility = Visibility.Hidden;
            TxtTimerSettings.Visibility = Visibility.Hidden;
            LblInfo.Visibility = Visibility.Hidden;
        }

       private void BtnVerbergWoord_Click(object sender, RoutedEventArgs e)
        {
            RegistreerZoekWoord();
            WoordMaskeren(string.Empty);
            ResetTimer();
            BtnRaad.IsEnabled = true;
            Tekst();
            Image();

            MnINieuwSpel.IsEnabled = true;
            MnITimer.Visibility= Visibility.Hidden;
            MnITimer.IsEnabled = false;
            BtnVerbergWoord.Visibility = Visibility.Collapsed;
            LblTimer.Visibility = Visibility.Visible;
            LblMaskingWoord.Visibility= Visibility.Visible;
            TxtWoord.Clear();
        }
        private void Tekst()
        {
            TxtTekst.Text = $"Levens: {levens}";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"Juiste letters:{ JuisteLetters }";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"Foute letters: { FouteLetters } ";
            TxtTekst.Text += Environment.NewLine;
        }
        private void RegistreerZoekWoord()
        {
            var woordLower = TxtWoord.Text.ToLower();
            ZoekWoordArray = woordLower. ToCharArray(0, TxtWoord.Text.Length);
            woord = woordLower;
            TxtWoord.Clear();
        }

        private void WoordMaskeren(string guess)
        {

           
            string tempcontent = LblMaskingWoord.Content.ToString();
            char[] tempchar = tempcontent.ToCharArray();
            LblMaskingWoord.Content = string.Empty;
            for (int i = 0; i < ZoekWoordArray.Length; i++)
            {
                
                if (guess.Length > 0 && ZoekWoordArray[i] == guess.ToCharArray()[0])
                {
                    LblMaskingWoord.Content += $"{ZoekWoordArray[i]}";
                    
                }
                else if (tempchar.Length == ZoekWoordArray.Length && !tempchar[i].Equals('*'))
                {
                    LblMaskingWoord.Content += $"{ZoekWoordArray[i]}";
                }
                else
                {
                    LblMaskingWoord.Content += "*";
                }
            }

        }

        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Timer--;
            if (Timer == 0)
            {
                timer.Stop();
                levens--;
                TxtTekst.Background = Brushes.Red;
                MessageBox.Show($"De tijd is op, u verliest 1 leven");
                ResetTimer();
                Image();

            }
            LblTimer.Content = Timer.ToString();
            Tekst();
            


        }
        private void StartTimer()
        {
            timer.Start();
        }

        private void ResetTimer()
        {
            TimerSettings();
            LblTimer.Content = Timer.ToString();
            StartTimer();
            TxtTekst.Background = Brushes.LightCoral;
        }



       private void BtnRaad_Click(object sender, RoutedEventArgs e)
        {
            var woordLower = TxtWoord.Text.ToLower();

            if (woordLower.Length == 1 && woord.Contains(woordLower) && levens != 0)
            {
                WoordMaskeren(woordLower);
                JuisteLetters.Append(woordLower);
                ResetTimer();
                TxtWoord.Clear();
                if (LblMaskingWoord.Content.Equals(woord))
                {
                    BtnRaad.IsEnabled = false;
                    timer.Stop();
                    TxtWoord.Clear();
                    TxtWoord.IsEnabled = false;
                    MessageBox.Show($"Proficiat u heeft {woord} geraden, druk op Nieuw Spel om opnieuw te beginnen");
                }
                
            }

            else if (woord == woordLower)
            {
                BtnRaad.IsEnabled = false;
                timer.Stop();
                TxtWoord.Clear();
                TxtWoord.IsEnabled = false;
                MessageBox.Show($"Proficiat u heeft {woord} geraden, druk op Nieuw Spel om opnieuw te beginnen");
            }
            else
            {
                levens--;
                FouteLetters.Append(woordLower);
                ResetTimer();
                TxtWoord.Clear();
            }
            if (levens == 0)
            {
                timer.Stop();
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\10.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
                MessageBox.Show("U levens zijn op, u heeft verloren, druk op Nieuw Spel om opnieuw te beginnen");
                BtnRaad.IsEnabled = false;

                TxtWoord.Clear();
                TxtWoord.IsEnabled = false;
            }
            MnINieuwSpel.IsEnabled = true;
            Tekst();
            Image();

        }
        public void Image()
        {
            var picture = 10 - levens;
            BitmapImage bitmap = new BitmapImage(new Uri($@"Pictures\{picture}.PNG", UriKind.RelativeOrAbsolute));
            ImgHangMan.Source = bitmap;
        }

        private void MnINieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            NieuwspelMenuShow();
            MessageBox.Show("Wil je een nieuw spel starten? Druk op de knop Nieuw Spel");
        }
        private void NieuwspelMenuShow()
        {
            LblInfo.Visibility = Visibility.Hidden;
            TxtTimerSettings.Visibility = Visibility.Hidden;
            LblTimer.Visibility = Visibility.Hidden;
            LblMaskingWoord.Visibility = Visibility.Hidden;
            BtnNieuwSpel.IsEnabled = true;
            BtnVerbergWoord.Visibility = Visibility.Visible;
            TxtWoord.Visibility = Visibility.Visible;
            BtnRaad.Visibility = Visibility.Visible;
            BtnNieuwSpel.Visibility = Visibility.Visible;
            BtnRaad.IsEnabled = true;
            BtnVerbergWoord.IsEnabled = true;
            ImgHangMan.Visibility = Visibility.Visible;
            TxtTekst.Visibility = Visibility.Visible;
        }

        private void MnISpelAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void MnITimer_Click(object sender, RoutedEventArgs e)
        {

            TimerMenuHidden();
            TimerSettings();
        }
        private void TimerSettings()
        {
        
            int Tijd = 0;
            int.TryParse(TxtTimerSettings.Text, out Tijd);
            if (Tijd <= 4 || Tijd >= 21)
            {
                MnINieuwSpel.IsEnabled=false;
                Timer = 10;
                
            }
            else if (Tijd >= 4 && Tijd <= 21)
            {
                MnINieuwSpel.IsEnabled = true;
                Timer = Tijd;
            }
            
        }
        private void TimerMenuHidden()
        {
            MnINieuwSpel.IsEnabled = false;
            LblInfo.Visibility = Visibility.Visible;
            TxtTimerSettings.Visibility = Visibility.Visible;
            LblTimer.Visibility = Visibility.Hidden;
            LblMaskingWoord.Visibility = Visibility.Hidden;
            BtnNieuwSpel.IsEnabled = false;
            BtnVerbergWoord.Visibility = Visibility.Hidden;
            TxtWoord.Visibility = Visibility.Hidden;
            BtnRaad.Visibility = Visibility.Hidden;
            BtnNieuwSpel.Visibility = Visibility.Hidden;
            BtnRaad.IsEnabled = false;
            BtnVerbergWoord.IsEnabled = false;
            ImgHangMan.Visibility = Visibility.Hidden;
            TxtTekst.Visibility = Visibility.Hidden;
        }
    }
}
