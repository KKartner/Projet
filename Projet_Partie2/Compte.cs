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
        public string Appartenance { get; set; }

        public Compte(string identifiant, DateTime date, float solde, string appartenance)
        {
            Identifiant = identifiant;
            DateOuverture = date;
            DateCloture = DateTime.MinValue;
            Solde = solde;
            Appartenance = appartenance;
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

        public bool ClotureCompte(List<Compte> listeCompte, string appartenanceCompte, DateTime dateCloture)
        {
            for (int i = 0; i < listeCompte.Count; i++)
            {
                if (listeCompte[i].Appartenance == appartenanceCompte && listeCompte[i].DateOuverture < dateCloture)
                {
                    return true;
                }
            }
            return false;
        }

        public bool GestionCompte(List<Gestionnaire> listeGestionnaire, string identifiantGestionnaire)
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
    }
}
