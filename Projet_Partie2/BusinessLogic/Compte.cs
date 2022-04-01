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
        public List<DateTime> HistoriqueDateTransaction { get; set; }
        public List<float> HistoriqueSommeTransaction { get; set; }
        public float Solde { get; set; }
        public string Appartenance { get; set; }

        public Compte(string identifiant, DateTime date, float solde, string appartenance)
        {
            Identifiant = identifiant;
            DateOuverture = date;
            DateCloture = DateTime.MinValue;
            HistoriqueDateTransaction = new List<DateTime>();
            HistoriqueSommeTransaction = new List<float>();
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

        public bool HistoriqueCompte(Compte compte, float montant, DateTime dateTransaction)
        {
            float somme = 0;
            if (compte.HistoriqueDateTransaction.Count != 0) 
            {
                TimeSpan limite = new TimeSpan(7, 0, 0, 0, 0);
                DateTime derniereTransaction = dateTransaction - limite;

                for (int i = 0; i < compte.HistoriqueDateTransaction.Count; i++)
                {
                    if (compte.HistoriqueDateTransaction[i] >= derniereTransaction && compte.HistoriqueDateTransaction[i] <= dateTransaction)
                    {
                        somme += compte.HistoriqueSommeTransaction[i];
                    }
                }
                if (somme + montant <= 2000)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
