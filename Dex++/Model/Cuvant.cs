using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dex__.Model
{
    public class Cuvant
    {
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }


        private string word;

        public string Word
        {
            get { return word; }
            set { word = value; }
        }


        private string definitie;

        public string Definitie
        {
            get { return definitie; }
            set { definitie = value; }
        }


        private string categorie;


        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }



    }
}
