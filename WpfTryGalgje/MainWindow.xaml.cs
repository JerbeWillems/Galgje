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
        string woord;
        int levens;
        StringBuilder JuisteLetters = new StringBuilder();
        StringBuilder FouteLetters = new StringBuilder();

        
        public void BtnNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            TxtTekst.Text = "Geheim woord ingeven";
            BtnRaad.IsEnabled = false;
            TxtWoord.Clear();
            BtnVerbergWoord.Visibility = Visibility.Visible;
            JuisteLetters.Clear();
            FouteLetters.Clear();
            levens = 10;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtTekst.Text = "Geheim woord ingeven";
            BtnRaad.IsEnabled = false;
            levens = 10;
        }

        public void BtnVerbergWoord_Click(object sender, RoutedEventArgs e)
        {
            BtnRaad.IsEnabled = true;
            woord = TxtWoord.Text;
            TxtTekst.Text = $"Levens: {levens}";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"Juiste letters:{ JuisteLetters }";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"Foute letters: { FouteLetters } ";
            TxtTekst.Text += Environment.NewLine;
            BtnVerbergWoord.Visibility = Visibility.Collapsed;
            TxtWoord.Clear();
            BitmapImage bitmap = new BitmapImage(new Uri(@"galgje geen fout.PNG", UriKind.RelativeOrAbsolute));
            Image image = new Image();
            image.Source = bitmap;
            TxtHangMan.Text = bitmap.ToString();
        }


        public void BtnRaad_Click(object sender, RoutedEventArgs e)
        {
            Letter();

            if (woord.Contains(TxtWoord.Text) && levens != 0 && woord != TxtWoord.Text)
            {
                JuisteLetters.Append(TxtWoord.Text);
            }
            else if (woord == TxtWoord.Text)
            {
                MessageBox.Show($"Proficiat u heeft {woord} geraden, druk op Nieuw Spel om opnieuw te beginnen");
                BtnRaad.IsEnabled = false;
            }
            else if (levens == 0)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 10de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
                MessageBox.Show("U levens zijn op, u heeft verloren, druk op Nieuw Spel om opnieuw te beginnen");
                BtnRaad.IsEnabled = false;
            }
            else 
            {
                levens--;
                FouteLetters.Append(TxtWoord.Text);
            }
            TxtTekst.Text = $"Levens: {levens}";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"Juiste letters:{ JuisteLetters }";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"Foute letters: { FouteLetters } ";
            TxtTekst.Text += Environment.NewLine;
            TxtTekst.Text += $"{Letter()}";
            Image();

        }
        char[] LetterArray;
        public char Letter()
        {
            char letter = TxtWoord.Text.ToCharArray()[0];
            if ((woord = woord.ToLower()).Contains(letter) && levens != 0 && woord != TxtWoord.Text)
            {
                char[] LetterArray = woord.ToCharArray();

                for (int i = 0; i < woord.Length; i++)
                {
                    if (LetterArray[i] == letter)
                    {
                        TxtTekst.Text = letter.ToString();
                    }
                }
            }
            else
            {
                
            }
            return letter;

        }
        public void Image()
        {
            if (levens == 9)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 1ste fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 8)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 2de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 7)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 3de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 6)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 4de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 5)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 5de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 4)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 6de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 3)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 7de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 2)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 8ste fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
            if (levens == 1)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"galgje 9de fout.PNG", UriKind.RelativeOrAbsolute));
                Image image = new Image();
                image.Source = bitmap;
                TxtHangMan.Text = bitmap.ToString();
            }
        }
    }
}
