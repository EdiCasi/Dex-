using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// Interaction logic for ModAdministrativ.xaml
    /// </summary>
    public partial class ModAdministrativ : UserControl
    {
        public ModAdministrativ()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.setContent(parentWindow.Home);
                clearWindow();
            }
            parentWindow.viewModel.writeCuvinteInFile();
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == true)
                selectIamge.Text = openFileDialog.FileName;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.viewModel.removeCuvantFormCuvinte(cuvantName.Text);
            }

            cuvantName.Text = "";
        }

        private void AddModify_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
            if (addCategorie.Text != "")
            {
                parentWindow.viewModel.addCategorie(addCategorie.Text);
                MessageBox.Show("categoria: " + addCategorie.Text + " a fost adaugata cu succes !");
            }
            if (cuvantName.Text != "")
            {
                if (parentWindow.viewModel.GetCuvantFormText(cuvantName.Text, "") == null)
                {
                    if (addCategorie.Text != "")
                    {
                        parentWindow.viewModel.adaugareCuvant(cuvantName.Text, cuvantDefinition.Text, addCategorie.Text, selectIamge.Text);
                        clearWindow();
                    }
                    else
                    {
                        parentWindow.viewModel.adaugareCuvant(cuvantName.Text, cuvantDefinition.Text, selectCategorie.Text, selectIamge.Text);
                        clearWindow();
                    }
                }
                else
                {
                    if (addCategorie.Text != "")
                    {
                        parentWindow.viewModel.modificareCuvant(cuvantName.Text, cuvantDefinition.Text, addCategorie.Text, selectIamge.Text);
                        clearWindow();
                    }
                    else
                    {
                        parentWindow.viewModel.modificareCuvant(cuvantName.Text, cuvantDefinition.Text, selectCategorie.Text, selectIamge.Text);
                        clearWindow();
                    }
                }
            }
        }

        private void clearWindow()
        {
            cuvantName.Text = "";

            cuvantDefinition.Text = "";

            addCategorie.Text = "";

            selectIamge.Text = "";

            selectCategorie.Text = "";
        }

        private void selectCategorie_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (selectCategorie.Text == "")
            {
                categorieList.Visibility = Visibility.Hidden;
                return;
            }

            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

            parentWindow.viewModel.ModifyCategoriiAfisate(selectCategorie.Text);

            if (parentWindow.viewModel.CategoriiAfisate.Count != 0)
                categorieList.Visibility = Visibility.Visible;

            categorieList.ItemsSource = parentWindow.viewModel.CategoriiAfisate;
            if (addCategorie.Text != "")
                addCategorie.Text = "";
        }

        private void categorieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categorieList.SelectedItem == null)
                return;

            selectCategorie.Text = (string)categorieList.SelectedItem;

            categorieList.Visibility = Visibility.Hidden;
        }

        private void addCategorie_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (addCategorie.Text == "")
                return;
            selectCategorie.Text = "";
        }
    }
}
