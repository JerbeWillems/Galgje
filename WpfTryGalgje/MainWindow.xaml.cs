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
        }


        public void BtnRaad_Click(object sender, RoutedEventArgs e)
        {

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
        }
    }
}
