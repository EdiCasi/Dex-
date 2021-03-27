using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            Categorii = new List<string>()
            {
                "blabla","blabla","anaa"
            };

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
                    if (categorieSelectata == "" || cuvant.Categorie == categorieSelectata)
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
                    if (entries.Length > 3)
                        cuvantNou.ImagePath = entries[3];
                }

                Cuvinte.Add(cuvantNou);
            }

        }

        public Cuvant GetCuvantFormText(string cuvantNou)
        {
            foreach (Cuvant cuvant in Cuvinte)
            {
                if (cuvant.Word == cuvantNou)
                    return cuvant;
            }
            return null;
        }

    }
}
