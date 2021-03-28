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

namespace Dex__.View
{
    
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Cautare_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.setContent(parentWindow.Cautare);
            }
        }

        private void Administrativ_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.setContent(parentWindow.Administrativ);
            }

        }

        private void Divertisment_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            
            if (parentWindow != null)
            {
                parentWindow.setContent(parentWindow.Divertisment);
                parentWindow.Divertisment.displayDefaultWindow();
            }
        }
    }
}
