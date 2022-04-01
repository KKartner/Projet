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
    }
}
