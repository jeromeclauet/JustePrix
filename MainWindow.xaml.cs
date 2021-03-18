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

namespace JustePrix
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int NbrToGuess = new Random().Next(1, 51);
        public int NbrTry = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string UserInput = TextBoxUserInput.Text;
            if (int.TryParse(UserInput, out int UserNumber))
            {
                if (UserNumber < 1 || UserNumber > 50)
                {
                    MessageBox.Show("La valeur saisie n'est pas dans les limites", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (UserNumber > NbrToGuess)
                    {
                        NbrTry++;
                        MessageBox.Show("C'est plus petit", "Faux", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (UserNumber < NbrToGuess)
                    {
                        NbrTry++;
                        MessageBox.Show("C'est plus grand", "Faux", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (UserNumber == NbrToGuess)
                    {
                        MessageBox.Show("Bravo, vous avez gagné!!\nLe prix a deviner était " + NbrToGuess + ".\nVous avez trouvé en " + NbrTry + " essais.", "Bravo");
                        ButtonPlay.Visibility = Visibility.Visible;
                        TextBlockObjectToGuess.Visibility = Visibility.Hidden;
                        TextBoxUserInput.Visibility = Visibility.Hidden;
                        ButtonTryNbr.Visibility = Visibility.Hidden;
                        LabelForUserInput.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                MessageBox.Show("La valeur saisie n'est pas un nombre", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonPlay.Visibility = Visibility.Hidden;
            TextBlockObjectToGuess.Visibility = Visibility.Visible;
            TextBoxUserInput.Visibility = Visibility.Visible;
            ButtonTryNbr.Visibility = Visibility.Visible;
            LabelForUserInput.Visibility = Visibility.Visible;
            TextBoxUserInput.Text = ""; 
            NbrTry = 0;
            NbrToGuess = new Random().Next(1, 51);
        }
    }
}
