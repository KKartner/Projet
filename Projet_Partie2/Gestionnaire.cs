using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Gestionnaire
    {
        public string Identifiant { get; set; }
        public string Type { get; set; }
        public int NbTransaction { get; set; }

        public Gestionnaire(string identifiant, string type, int nbTransaction)
        {
            Identifiant = identifiant;
            Type = type;
            NbTransaction = nbTransaction;
        }

        public List<Gestionnaire> CreateGestionary(string input)
        {
            List<Gestionnaire> listeGestionnaires = new List<Gestionnaire>();
            using (StreamReader sr = new StreamReader(input))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    Gestionnaire nouveauGestionnaire = new Gestionnaire("", "", 0);
                    string[] line = lines.Split(';');

                    int nombreTransaction = LigneFichier.ConvertStringToInt(line[2]);
                    if (nombreTransaction != int.MinValue)
                    {
                        nouveauGestionnaire.Identifiant = line[0];
                        nouveauGestionnaire.Type = line[1];
                        nouveauGestionnaire.NbTransaction = nombreTransaction;
                        listeGestionnaires.Add(nouveauGestionnaire);

                    }
                }
            }
            return listeGestionnaires;
        }
    }
}
