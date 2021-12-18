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

        }
        char[] ZoekWoordArray;
        char[] VerbergWoordArray;
        string woord;
        int levens;
        StringBuilder JuisteLetters = new StringBuilder();
        StringBuilder FouteLetters = new StringBuilder();
        int goktijd = 10;
        DispatcherTimer timer = new DispatcherTimer();



        public void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
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
            ZoekWoordArray = new char[] { };
            VerbergWoordArray = new char[] { };
            TxtWoord.IsEnabled = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTekst.Text = "Geheim woord ingeven";
            BtnRaad.IsEnabled = false;
            levens = 10;
        }

        public void BtnVerbergWoord_Click(object sender, RoutedEventArgs e)
        {
            RegistreerZoekWoord();
            WoordMaskeren();
            timer.Tick += new EventHandler(DispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            StartTimer();
            BtnRaad.IsEnabled = true;
            woord = TxtWoord.Text;
            Tekst();
            Image();
            BtnVerbergWoord.Visibility = Visibility.Collapsed;
            LblTimer.Visibility = Visibility.Visible;
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
            TxtTekst.Text += $"{string.Join("", VerbergWoordArray)}";
        }
        private void RegistreerZoekWoord()
        {
            ZoekWoordArray = TxtWoord.Text.ToCharArray(0, TxtWoord.Text.Length);
        }

        private void WoordMaskeren()
        {

            VerbergWoordArray = new char[ZoekWoordArray.Length];

            for (int i = 0; i < ZoekWoordArray.Length; i++)
            {
                VerbergWoordArray[i] = '*';
            }

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            goktijd--;
            if (goktijd == 0)
            {
                timer.Stop();
                levens--;
                TxtTekst.Background = Brushes.Red;
                MessageBox.Show("De tijd is op, u heeft maar 10 seconden");
                ResetTimer();
                

            }
            LblTimer.Content = goktijd.ToString();
            Tekst();
            Image();


        }
        private void StartTimer()
        {
            timer.Start();
        }

        private void ResetTimer()
        {
            goktijd = 10;
            LblTimer.Content = goktijd.ToString();
            StartTimer();
            TxtTekst.Background = Brushes.LightCoral;
        }



        public void BtnRaad_Click(object sender, RoutedEventArgs e)
        {

            if (woord.Contains(TxtWoord.Text) && levens != 0 && woord != TxtWoord.Text)
            {
                JuisteLetters.Append(TxtWoord.Text);
                ResetTimer();
                TxtWoord.Clear();
                
            }
            else if (woord == TxtWoord.Text)
            {
                MessageBox.Show($"Proficiat u heeft {woord} geraden, druk op Nieuw Spel om opnieuw te beginnen");
                BtnRaad.IsEnabled = false;
                timer.Stop();
                TxtWoord.Clear();
                TxtWoord.IsEnabled = false;
            }
            else if (levens == 0)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\10.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
                MessageBox.Show("U levens zijn op, u heeft verloren, druk op Nieuw Spel om opnieuw te beginnen");
                BtnRaad.IsEnabled = false;
                timer.Stop();
                TxtWoord.Clear();
                TxtWoord.IsEnabled = false;
            }
            else
            {
                levens--;
                FouteLetters.Append(TxtWoord.Text);
                ResetTimer();
                TxtWoord.Clear();
            }
            Tekst();
            Image();

        }
        public void Image()
        {
            if (levens == 10)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures/Galgje geen fout.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 9)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\1.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 8)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\2.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 7)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\3.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 6)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\4.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 5)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\5.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 4)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\6.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 3)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\7.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 2)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\8.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
            if (levens == 1)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"Pictures\9.PNG", UriKind.RelativeOrAbsolute));
                ImgHangMan.Source = bitmap;
            }
        }
    }
}
