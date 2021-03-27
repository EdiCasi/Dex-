using Dex__.Model;
using Dex__.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Dex__
{
    public partial class MainWindow : Window
    {
        public ViewModel viewModel { get; set; }
        public Home Home { get; set; }

        public  ModCautare Cautare { get; set; }

        public ModAdministrativ Administrativ { get; set; }

        public ModDivertisment Divertisment { get; set; }

        public MainWindow()
        {
            Home = new Home();
            Cautare = new ModCautare();
            Administrativ = new ModAdministrativ();
            Divertisment = new ModDivertisment();
            viewModel = new ViewModel();
            InitializeComponent();

            this.Content = Home;
        }

        public void setContent(UserControl userControl)
        {
            this.Content = userControl;
        }

        public void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            viewModel.writeCuvinteInFile();
        }

    }
}
