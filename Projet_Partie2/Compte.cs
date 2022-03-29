using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Compte
    {
        public string Identifiant { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateCloture { get; set; }
        public float Solde { get; set; }

        public Compte(string identifiant, DateTime date, float solde)
        {
            Identifiant = identifiant;
            DateOuverture = date;
            DateCloture = DateTime.MinValue;
            Solde = solde;
        }
    }
}
