using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Dex__.View
{
    public partial class ModDivertisment : UserControl, INotifyPropertyChanged
    {
        private int greseli;

        public int Greseli
        {
            get { return greseli; }
            set { greseli = value; NotifyPropertyChanged(); }
        }

        public string CuvantGhicit { get; set; }

        private string cuvantAfisat;
        public string CuvantAfisat
        {
            get { return cuvantAfisat; }
            set { cuvantAfisat = value; NotifyPropertyChanged(); }
        }

        private bool gameOver;

        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }



        public ModDivertisment()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.setContent(parentWindow.Home);
            }
        }
        private void try_Click(object sender, RoutedEventArgs e)
        {
            if (GameOver)
                return;

            string input = litere.Text;
            for (int i = 0; i < input.Length; i++)
            {
                bool modificare = false;
                for (int j = 0; j < CuvantGhicit.Length; j++)
                    if (input[i] == CuvantGhicit[j])
                    {
                        StringBuilder someString = new StringBuilder(CuvantAfisat);
                        someString[j] = CuvantGhicit[j];
                        CuvantAfisat = someString.ToString();
                        modificare = true;
                    }
                if (modificare == false)
                    Greseli++;
            }


            litere.Text = "";


            if (verifyIfCuvantAfisatIsComplete())
            {
                TitleText.Text = "Ai Castigat !";
                TitleText.Foreground = new SolidColorBrush(Colors.Green);
                gameOver = true;
                ReMatch.Visibility = Visibility.Visible;
            }
            if (Greseli == 10)
            {
                TitleText.Text = "Ai Pierdut !";
                TitleText.Foreground = new SolidColorBrush(Colors.Red);
                ReMatch.Visibility = Visibility.Visible;
                gameOver = true;
            }
        }

        public bool verifyIfCuvantAfisatIsComplete()
        {
            return CuvantAfisat == CuvantGhicit;
        }

        public void displayDefaultWindow()
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

            if (parentWindow != null)
            {
                CuvantGhicit = parentWindow.viewModel.returnRandomCuvant();

                if (parentWindow != null)
                    CuvantAfisat = "";

                for (int i = 0; i < CuvantGhicit.Length; i++)
                    CuvantAfisat = CuvantAfisat + "#";
            }
            Greseli = 0;

            TitleText.Text = "Spânzurătoarea";

            ReMatch.Visibility = Visibility.Hidden;

            TitleText.Foreground = new SolidColorBrush(Colors.Black);

            GameOver = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ReMatch_Click(object sender, RoutedEventArgs e)
        {
            displayDefaultWindow();
        }
    }
}
