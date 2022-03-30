using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Transaction
    {
        public string Identifiant { get; set; }
        public DateTime Date { get; set; }
        public float Montant { get; set; }
        public string Expediteur { get; set; }
        public string Destinataire { get; set; }

        private const int MontantMaxTrans = 1000;

        public Transaction(string identifiant, DateTime date, float solde, string expediteur, string destinataire)
        {
            Identifiant = identifiant;
            Date = date;
            Montant = solde;
            Expediteur = expediteur;
            Destinataire = destinataire;
        }
        public bool DeposeArgent(List<Compte> listeCompte, string numeroCompte, float montant, DateTime dateEffet)
        {
            for (int i = 0; i < listeCompte.Count; i++)
            {
                if (listeCompte[i].Identifiant == numeroCompte)
                {
                    if (montant > 0 && listeCompte[i].DateOuverture < dateEffet)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RetirerArgent(List<Compte> listeCompte, string numeroCompte, float montant, DateTime dateEffet)
        {
            for (int i = 0; i < listeCompte.Count; i++)
            {
                if (listeCompte[i].Identifiant == numeroCompte)
                {
                    if (listeCompte[i].DateOuverture < dateEffet && montant > 0 && listeCompte[i].Solde >= montant && montant <= MontantMaxTrans)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool VirementPrevelement()
        {
            return false;
        }
    }
}
