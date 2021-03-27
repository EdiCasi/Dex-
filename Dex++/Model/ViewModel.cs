using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dex__.Model
{
    public class ViewModel
    {

        private List<Cuvant> Cuvinte { get; set; }
        public ObservableCollection<Cuvant> CuvinteAfisate { get; set; }

        private List<string> Categorii { get; set; }

        public ObservableCollection<string> CategoriiAfisate { get; set; }

        public ViewModel()
        {
            Categorii = new List<string>();
            Categorii.Add("none");

            CategoriiAfisate = new ObservableCollection<string>();


            Cuvinte = new List<Cuvant>();

            CuvinteAfisate = new ObservableCollection<Cuvant>();

            ReadWordsAndDefinitions();
        }

        public void ModifyCategoriiAfisate(string categorieNoua)
        {
            CategoriiAfisate.Clear();

            String categorieNouaLowerCase = categorieNoua.ToLower();

            foreach (string categorie in Categorii)
            {
                if (categorie.IndexOf(categorieNouaLowerCase) == 0)
                    CategoriiAfisate.Add(categorie);
            }
        }

        public void ModifyCuvinteAfisate(String cuvantNou, string categorieSelectata)
        {
            CuvinteAfisate.Clear();

            String cuvantNouLowerCase = cuvantNou.ToLower();

            foreach (Cuvant cuvant in Cuvinte)
            {
                if (cuvant.Word.IndexOf(cuvantNouLowerCase) == 0)
                {
                    if (categorieSelectata == "" ||
                        categorieSelectata == "none" ||
                        cuvant.Categorie == categorieSelectata)
                        CuvinteAfisate.Add(cuvant);
                }
            }
        }

        public void ReadWordsAndDefinitions()
        {
            string filePath = @"C:\C# Test\Words.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(';');

                Cuvant cuvantNou = new Cuvant();

                cuvantNou.Word = entries[0];

                cuvantNou.Definitie = entries[1];

                if (entries.Length > 2)
                {
                    cuvantNou.Categorie = entries[2];
                    addCategorie(entries[2]);
                    if (entries.Length > 3)
                        cuvantNou.ImagePath = entries[3];
                }
                else
                {
                    cuvantNou.Categorie = "none";
                    cuvantNou.ImagePath = @"C:\C# Test\default.jpg";
                }
                Cuvinte.Add(cuvantNou);
            }

        }

        public Cuvant GetCuvantFormText(string cuvantNou, string categorie)
        {
            foreach (Cuvant cuvant in Cuvinte)
            {
                if (cuvant.Word == cuvantNou)
                {
                    if (cuvant.Categorie == categorie || categorie == "none" || categorie == "")
                        return cuvant;
                }
            }
            return null;
        }

        public void addCategorie(string categorieNoua)
        {
            if (!verifyIfCategorieExists(categorieNoua))
                Categorii.Add(categorieNoua);
        }

        public bool verifyIfCategorieExists(string categorieNoua)
        {
            return Categorii.Contains(categorieNoua);
        }

        public void removeCuvantFormCuvinte(string cuvant)
        {
            int index = Cuvinte.FindIndex(c => c.Word == cuvant);
            if (index != -1)
            {
                Cuvinte.RemoveAt(index);
                MessageBox.Show("Cuvantul: " + cuvant + " a fost sters !");

            }
            else
                MessageBox.Show("Cuvant negasit !");
        }

        public void adaugareCuvant(string cuvantName, string definitie, string categorie, string imagePath)
        {
            Cuvant cuvantNou = new Cuvant();

            cuvantNou.Word = cuvantName;

            if (definitie == "")
            {
                MessageBox.Show("Campul de definitie este obligatoriu!");
                return;
            }
            else cuvantNou.Definitie = definitie;

            if (categorie == "")
                cuvantNou.Categorie = "none";
            else cuvantNou.Categorie = categorie;

            if (imagePath == "")
                cuvantNou.ImagePath = @"C:\C# Test\default.jpg";

            Cuvinte.Add(cuvantNou);

            MessageBox.Show("Cuvantul: " + cuvantName + "a fost adaugat cu succes !");
        }

        public void modificareCuvant(string cuvantName, string definitie, string categorie, string imagePath)
        {
            Cuvant cuvant = GetCuvantFormText(cuvantName, "");

            bool modificareFacuta = false;

            if (definitie != "")
            {
                cuvant.Definitie = definitie;
                modificareFacuta = true;
            }

            if (categorie != "")
            {
                cuvant.Categorie = categorie;
                modificareFacuta = true;
            }

            if (imagePath != "")
            {
                cuvant.ImagePath = imagePath;
                modificareFacuta = true;
            }
            if (modificareFacuta)
                MessageBox.Show("Modificarea a fost facuta cu succes!");
        }

        public void writeCuvinteInFile()
        {
            StreamWriter sw = new StreamWriter(@"C:\C# Test\Words.txt");
            foreach (Cuvant cuvant in Cuvinte)
            {
                string line = cuvant.Word + ";" + cuvant.Definitie + ";" + cuvant.Categorie + ";" + cuvant.ImagePath + ";";
                sw.WriteLine(line);
            }
            sw.Close();
        }
    }
}
