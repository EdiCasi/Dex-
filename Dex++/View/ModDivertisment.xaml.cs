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

    public ModDivertisment()
        {
            Greseli = 0;
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
            Greseli++;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
