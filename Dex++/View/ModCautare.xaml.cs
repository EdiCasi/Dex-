﻿using Dex__.Model;
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
    public partial class ModCautare : UserControl
    {

        private string categorieSelectata = "";

        public string CategorieSelectata
        {
            get { return categorieSelectata; }
            set { categorieSelectata = value; }
        }


        private Cuvant cuvantSelectat;
        public Cuvant CuvantSelectat
        {
            get { return cuvantSelectat; }
            set { cuvantSelectat = value; }
        }

        public ModCautare()
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

        private void CuvantTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

            CuvantListBox.Visibility = Visibility.Visible;

            parentWindow.viewModel.ModifyCuvinteAfisate(CuvantTextBox.Text, CategorieSelectata);

            CuvantListBox.ItemsSource = parentWindow.viewModel.CuvinteAfisate;

            if (CuvantTextBox.Text == "")
                CuvantListBox.Visibility = Visibility.Hidden;
        }

        private void CuvantListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

            if (CuvantListBox.SelectedItem == null)
                return;

            CuvantSelectat = (Cuvant)CuvantListBox.SelectedItem;

            CuvantTextBox.Text = CuvantSelectat.Word;

            CuvantListBox.Visibility = Visibility.Hidden;

            displayCuvantSelectat();
        }

        private void displayCuvantSelectat()
        {
            CuvantName.Text = CuvantSelectat.Word + " =";

            DeffinitionText.Text = CuvantSelectat.Definitie;

            CategorieText.Visibility = Visibility.Visible;

            if (CuvantSelectat.Categorie != null)
                CategorieName.Text = CuvantSelectat.Categorie;
            else CategorieName.Text = "none";

            if (cuvantSelectat.ImagePath != null)
                cuvantImage.Source = new BitmapImage(new Uri(cuvantSelectat.ImagePath, UriKind.RelativeOrAbsolute));
            else cuvantImage.Source = new BitmapImage(new Uri(@"C:\C# Test\default.jpg", UriKind.RelativeOrAbsolute));

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            if (CuvantTextBox.Text == "")
                return;

            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

            CuvantSelectat = parentWindow.viewModel.GetCuvantFormText(CuvantTextBox.Text);

            CuvantListBox.Visibility = Visibility.Hidden;

            if (cuvantSelectat == null)
            {
                ClearWindow();
                DeffinitionText.Text = "Cuvant negasit!";
            }
            else
            {
                CuvantTextBox.Text = "";
                displayCuvantSelectat();
            }

        }

        private void CategorieTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow parentWindow = Window.GetWindow(this) as MainWindow;

            parentWindow.viewModel.ModifyCategoriiAfisate(CategorieTextBox.Text);
            if (parentWindow.viewModel.CategoriiAfisate.Count != 0)
                CategorieListBox.Visibility = Visibility.Visible;
            else
                CategorieSelectata = "";

            CategorieListBox.ItemsSource = parentWindow.viewModel.CategoriiAfisate;

            if (CategorieTextBox.Text == "")
            {
                CategorieListBox.Visibility = Visibility.Hidden;
                CategorieSelectata = "";
            }

        }
        private void CategorieListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategorieListBox.SelectedItem == null)
                return;

            CategorieSelectata = (string)CategorieListBox.SelectedItem;

            CategorieTextBox.Text = CategorieSelectata;

            CategorieListBox.Visibility = Visibility.Hidden;
        }

        public void ClearWindow()
        {
            CuvantName.Text = "";

            DeffinitionText.Text = "";

            CategorieText.Visibility = Visibility.Hidden;

            CategorieName.Text = "";

            cuvantImage.Source = null;
        }

    }
}