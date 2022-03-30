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

        public bool CreationCompte(List<Gestionnaire> listeGestionnaire, string identifiantGestionnaire)
        {
            for (int i = 0; i < listeGestionnaire.Count; i++)
            {
                if (listeGestionnaire[i].Identifiant == identifiantGestionnaire)
                {
                    return true;
                }
            }
            return false;
        }

        public string ClotureCompte()
        {
            string value = "KO";

            return value;
        }

        public string GestionCompte()
        {
            string value = "KO";

            return value;
        }
    }
}
