using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class LigneFichier
    {
        public string Identifiant { get; set; }
        public DateTime Date { get; set; }
        public float Solde { get; set; }
        public string Entree { get; set; }
        public string Sortie { get; set; }
        public TypeFichier Type { get; set; }

        public LigneFichier(string identifiant, DateTime date, float solde, string entree, string sortie, TypeFichier type)
        {
            Identifiant = identifiant;
            Date = date;
            Solde = solde;
            Entree = entree;
            Sortie = sortie;
            Type = type;
        }

        public List<Compte> CreateAccount(string input, List<Gestionnaire> listeGestionnaire)
        {
            List<Compte> listeComptes = new List<Compte>();
            using (StreamReader sr = new StreamReader(input))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    Compte nouveauCompte = new Compte("", DateTime.MinValue, 0, "");
                    string[] line = lines.Split(';');

                    for (int i = 0; i < listeGestionnaire.Count; i++)
                    {
                        if (listeGestionnaire[i].Identifiant == line[3])
                        {
                            if (line[4] == "0")
                            {
                                int monSolde = ConvertStringToInt(line[2]);
                                if (monSolde != int.MinValue)
                                {
                                    nouveauCompte.Identifiant = line[0];
                                    DateTime dateCreation = Convert.ToDateTime(line[1]);
                                    nouveauCompte.DateOuverture = dateCreation;
                                    nouveauCompte.Solde = monSolde;
                                    listeComptes.Add(nouveauCompte);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            return listeComptes;
        }

        public static int ConvertStringToInt(string StringConvert)
        {
            int convertion = int.MinValue;
            if (int.TryParse(StringConvert.Replace('.', ','), out convertion))
            {
                return convertion;
            }
            return convertion;
        }
    }
}
